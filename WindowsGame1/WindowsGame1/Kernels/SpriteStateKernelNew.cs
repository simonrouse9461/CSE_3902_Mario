using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernelNew : ISpriteStateNew
    {
        public ICoreNew Core { protected get; set; }
        protected Counter SpriteTimer { get; set; }
        protected Counter ColorTimer { get; set; }

        private Collection<ISpriteNew> SpriteList { get; set; }
        protected Collection<ColorAnimator> ColorSchemeList { get; set; }

        private ISpriteNew _sprite;
        public ISpriteNew Sprite
        {
            get { return _sprite; }
            set { if (!Held) _sprite = value; }
        }

        private ISpriteNew LastSprite { get; set; }
        private bool HoldOrientation { get; set; }
        private int CycleWhenFinish { get; set; }
        private Action FinishAction { get; set; }
        
        protected virtual ColorAnimator ColorScheme { get { return null; } }

        public Color Color
        {
            get { return ColorScheme == null ? Color.White : ColorScheme.Color; }
        }

        public Orientation Orientation { get; private set; }
        public IConvertible Version { get; private set; }
        public bool Left { get { return Orientation == Orientation.Left; } }
        public bool Right { get { return Orientation == Orientation.Right; } }
        public bool Default { get { return Orientation == Orientation.Default; } }
        public bool Held { get; private set; }

        protected SpriteStateKernelNew()
        {
            SpriteTimer = new Counter();
            ColorTimer = new Counter();
            SpriteList = new Collection<ISpriteNew>();
            ToDefault();
        }

        public void AddSprite<T>() where T : ISpriteNew, new()
        {
            if (SpriteList.Any(s => s is T)) return;
            SpriteList.Add(new T());
        }

        public ISpriteNew FindSprite<T>() where T : ISpriteNew
        {
            return SpriteList.First(sprite => sprite is T);
        }

        public void SetSprite<T>() where T : ISpriteNew
        {
            Sprite = FindSprite<T>();
        }

        public bool IsSprite<T>() where T : ISpriteNew
        {
            return Sprite == FindSprite<T>();
        }

        public void SetVersion(IConvertible version)
        {
            foreach (var sprite in SpriteList)
            {
                sprite.SetVersion(version);
            }
            Version = version;
        }

        public void SetOrientation(Orientation orientation)
        {
            if (HoldOrientation) return;
            Orientation = orientation;
        }

        public void ToLeft()
        {
            SetOrientation(Orientation.Left);
        }

        public void ToRight()
        {
            SetOrientation(Orientation.Right);
        }

        public void ToDefault()
        {
            SetOrientation(Orientation.Default);
        }

        public void Hold(bool holdOrientation, int timer = 0, Action action = null)
        {
            HoldOrientation = holdOrientation;
            Held = true;
            if (timer > 0) Core.DelayCommand(() =>
            {
                Resume();
                if (action != null) action();
            }, timer);
        }

        public void HoldTillFinish(bool holdOrientation, int cycle, Action action = null)
        {
            HoldOrientation = holdOrientation;
            Held = true;
            CycleWhenFinish = cycle;
            FinishAction = action ?? (() => { });
        }

        public void HoldTillFinish(bool holdOrientation, Action action = null)
        {
            HoldTillFinish(holdOrientation, 1, action);
        }

        public void Resume()
        {
            Held = false;
            HoldOrientation = false;
        }

        public void Load(ContentManager content)
        {
            foreach (var sprite in SpriteList)
            {
                sprite.Load(content);
            }
        }

        public void SetSpriteFrequency(int frequency)
        {
            SpriteTimer.Reset(frequency);
        }

        public void SetColorFrequency(int frequency)
        {
            ColorTimer.Reset(frequency);
        }
         
        public void Reset()
        {
            SpriteTimer.Reset();
            ColorTimer.Reset();
            foreach (var sprite in SpriteList)
            {
                sprite.Reset();
            }
            foreach (var colorAnimator in ColorSchemeList)
            {
                colorAnimator.Reset();
            }
        }

        public virtual void Update()
        {
            if (LastSprite != null && LastSprite != Sprite) LastSprite.Reset();
            if (SpriteTimer.Update()) 
                Sprite.Update();
            if (!Held) CycleWhenFinish = 0;
            if (Held && CycleWhenFinish > 0 && Sprite.Cycle == CycleWhenFinish)
            {
                Resume();
                FinishAction();
            }
            if (ColorTimer.Update() &&ColorSchemeList != null)
            {
                foreach (var colorAnimator in ColorSchemeList)
                {
                    colorAnimator.Update();
                }
            }
            LastSprite = Sprite;
        }
    }
}