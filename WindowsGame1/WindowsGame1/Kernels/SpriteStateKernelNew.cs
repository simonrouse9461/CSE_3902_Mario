using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteStateKernelNew<TVersion> : ISpriteStateNew where TVersion : IConvertible
    {
        public ICoreNew Core { protected get; set; }
        protected Counter ColorTimer { get; set; }
        protected Counter SpriteTimer { get; set; }
        protected Counter VersionTimer { get; set; }

        private Collection<ISpriteNew> SpriteList { get; set; }
        private ISpriteNew _sprite;
        public ISpriteNew Sprite
        {
            get { return _sprite; }
            set { if (!Held) _sprite = value; }
        }
        private ISpriteNew LastSprite { get; set; }

        private Dictionary<IConvertible, PeriodicFunction<Color>> ColorSchemeList { get; set; }
        private PeriodicFunction<Color> ColorScheme { get; set; }
        public Color Color
        {
            get { return ColorScheme == null ? Color.White : ColorScheme.Value; }
        }

        private Dictionary<IConvertible, PeriodicFunction<TVersion>> VersionAnimatorList { get; set; }
        private PeriodicFunction<TVersion> VersionAnimator { get; set; }
        protected TVersion ActualVersion { get; set; }
        protected TVersion DefaultVersion { get; set; }
        public IConvertible Version
        {
            get
            {
                foreach (var sprite in SpriteList)
                {
                    sprite.SetVersion(ActualVersion);
                }
                return VersionAnimator == null ? ActualVersion : VersionAnimator.Value;
            }
            private set
            {
                ActualVersion = (TVersion)value;
            }
        }

        private bool HoldOrientation { get; set; }
        private int CycleWhenFinish { get; set; }
        private Action FinishAction { get; set; }
        

        public Orientation Orientation { get; private set; }
        public bool Left { get { return Orientation == Orientation.Left; } }
        public bool Right { get { return Orientation == Orientation.Right; } }
        public bool Default { get { return Orientation == Orientation.Default; } }
        public bool Held { get; private set; }

        protected SpriteStateKernelNew()
        {
            SpriteList = new Collection<ISpriteNew>();
            ColorSchemeList = new Dictionary<IConvertible, PeriodicFunction<Color>>();
            VersionAnimatorList = new Dictionary<IConvertible, PeriodicFunction<TVersion>>();
            SpriteTimer = new Counter();
            ColorTimer = new Counter();
            VersionTimer = new Counter();
            FaceDefault();
        }

        protected void AddSprite<T>() where T : ISpriteNew, new()
        {
            if (SpriteList.Any(s => s is T)) return;
            SpriteList.Add(new T());
        }

        protected ISpriteNew FindSprite<T>() where T : ISpriteNew
        {
            return SpriteList.First(sprite => sprite is T);
        }

        protected void SetSprite<T>() where T : ISpriteNew
        {
            Sprite = FindSprite<T>();
        }

        protected bool IsSprite<T>() where T : ISpriteNew
        {
            return Sprite == FindSprite<T>();
        }

        protected void AddColorScheme(IConvertible name, Color[] colorList)
        {
            ColorSchemeList.Add(name, new PeriodicFunction<Color>(i => colorList[i], colorList.Length));
        }

        protected void SetColorScheme(IConvertible name)
        {
            ColorScheme = ColorSchemeList[name];
        }

        protected bool IsColorScheme(IConvertible name)
        {
            return ColorScheme == ColorSchemeList[name];
        }

        protected void RestoreColorScheme()
        {
            ColorScheme = null;
        }

        protected void AddVersionAnimator(IConvertible name, TVersion[] versionList)
        {
            VersionAnimatorList.Add(name, new PeriodicFunction<TVersion>(i => versionList[i], versionList.Length));
        }

        protected void SetVersionAnimator(IConvertible name)
        {
            VersionAnimator = VersionAnimatorList[name];
        }

        protected bool IsVersionAnimator(IConvertible name)
        {
            return VersionAnimator == VersionAnimatorList[name];
        }

        protected void StopVersionAnimator()
        {
            VersionAnimator = null;
        }

        protected void SetVersion(TVersion version)
        {
            Version = version;
        }

        protected bool IsVersion(TVersion version)
        {
            return ActualVersion.Equals(version);
        }

        protected void SetDefaultVersion()
        {
            SetVersion(DefaultVersion);
        }

        protected void SetDefaultVersion(TVersion version)
        {
            DefaultVersion = version;
            SetDefaultVersion();
        }

        public void SetOrientation(Orientation orientation)
        {
            if (HoldOrientation) return;
            Orientation = orientation;
        }

        public void FaceLeft()
        {
            SetOrientation(Orientation.Left);
        }

        public void FaceRight()
        {
            SetOrientation(Orientation.Right);
        }

        public void FaceDefault()
        {
            SetOrientation(Orientation.Default);
        }

        public void Hold(bool holdOrientation, int timer = 0, Action action = null)
        {
            HoldOrientation = holdOrientation;
            action = action ?? (() => { });
            Held = true;
            if (timer > 0) Core.DelayCommand(() =>
            {
                Resume();
                action();
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

        public void SetVersionFrequency(int frequency)
        {
            VersionTimer.Reset(frequency);
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
                colorAnimator.Value.Reset();
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
            if (ColorTimer.Update() && ColorSchemeList != null)
            {
                foreach (var colorScheme in ColorSchemeList)
                {
                    colorScheme.Value.Update();
                }
            }
            if (VersionTimer.Update() && VersionAnimatorList != null)
            {
                foreach (var versionAnimator in VersionAnimatorList)
                {
                    versionAnimator.Value.Update();
                }
            }
            LastSprite = Sprite;
        }
    }
}