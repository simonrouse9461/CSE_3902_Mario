using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame
{
    public abstract class SpriteStateKernelNew<TVersion> : ISpriteStateNew where TVersion : IConvertible
    {
        protected ICoreNew Core;
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
        private LinkedList<PeriodicFunction<TVersion>> ActiveVersionAnimatorStack { get; set; }
        private PeriodicFunction<TVersion> EffectiveVersionAnimator
        {
            get { return ActiveVersionAnimatorStack.First == null ? null : ActiveVersionAnimatorStack.First.Value; }
        }
        private PeriodicFunction<TVersion> DependencyVersionAnimator { get; set; }
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
                return EffectiveVersionAnimator == null ? ActualVersion : EffectiveVersionAnimator.Value;
            }
            private set
            {
                ActualVersion = (TVersion)value;
            }
        }

        private SpriteHoldDependency HoldDependency { get; set; }
        public bool Held { get; private set; }
        private bool HoldOrientation { get; set; }
        private int CycleWhenFinish { get; set; }
        private Action FinishAction { get; set; }
        

        public Orientation Orientation { get; private set; }
        public bool Left { get { return Orientation == Orientation.Left; } }
        public bool Right { get { return Orientation == Orientation.Right; } }
        public bool DefaultSprite { get { return Orientation == Orientation.Default; } }

        protected SpriteStateKernelNew()
        {
            SpriteList = new Collection<ISpriteNew>();
            ColorSchemeList = new Dictionary<IConvertible, PeriodicFunction<Color>>();
            VersionAnimatorList = new Dictionary<IConvertible, PeriodicFunction<TVersion>>();
            ActiveVersionAnimatorStack = new LinkedList<PeriodicFunction<TVersion>>();
            SpriteTimer = new Counter();
            ColorTimer = new Counter();
            VersionTimer = new Counter();
            FaceDefault();
        }

        public void SetCore(ICoreNew c)
        {
            Core = c;
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
            ColorScheme.Reset();
            ColorScheme = null;
        }

        protected void AddVersionAnimator(IConvertible name, TVersion[] versionList)
        {
            VersionAnimatorList.Add(name, new PeriodicFunction<TVersion>(i => versionList[i], versionList.Length));
        }

        protected void SetVersionAnimator(IConvertible name)
        {
            ActiveVersionAnimatorStack.AddFirst(VersionAnimatorList[name]);
        }

        protected bool IsVersionAnimator(IConvertible name)
        {
            return ActiveVersionAnimatorStack.Contains(VersionAnimatorList[name]);
        }

        protected void StopVersionAnimator(IConvertible name)
        {
            ActiveVersionAnimatorStack.Remove(VersionAnimatorList[name]);
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
            HoldDependency = SpriteHoldDependency.Updates;
            if (timer > 0) Core.DelayCommand(() =>
            {
                Release();
                action();
            }, timer);
        }

        public void HoldTillFinish(bool holdOrientation, SpriteHoldDependency dependency, int cycle, Action action = null)
        {
            if (dependency == SpriteHoldDependency.Updates)
            {
                Hold(holdOrientation, cycle, action);
                return;
            }
            HoldOrientation = holdOrientation;
            Held = true;
            HoldDependency = dependency;
            DependencyVersionAnimator = EffectiveVersionAnimator;
            CycleWhenFinish = cycle;
            FinishAction = action ?? (() => { });
        }

        public void HoldTillFinish(bool holdOrientation, SpriteHoldDependency dependency, Action action = null)
        {
            HoldTillFinish(holdOrientation, dependency, 1, action);
        }

        public void HoldTillFinish(bool holdOrientation, int cycle = 1, Action action = null)
        {
            HoldTillFinish(holdOrientation, SpriteHoldDependency.SpriteAnimation, cycle, action);
        }

        public void Release()
        {
            Held = false;
            HoldOrientation = false;
            CycleWhenFinish = 0;
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
            if (SpriteTimer.Update()) Sprite.Update();
            if (ColorTimer.Update())
            {
                foreach (var colorScheme in ColorSchemeList)
                {
                    if (colorScheme.Value == ColorScheme) colorScheme.Value.Update();
                    else colorScheme.Value.Reset();
                }
            }
            if (VersionTimer.Update())
            {
                foreach (var versionAnimator in VersionAnimatorList)
                {
                    if (ActiveVersionAnimatorStack.Contains(versionAnimator.Value)) versionAnimator.Value.Update();
                    else versionAnimator.Value.Reset();
                }
            }

            if (Held)
            {
                var cycle = -1;
                switch (HoldDependency)
                {
                    case SpriteHoldDependency.SpriteAnimation:
                        cycle = Sprite.Cycle;
                        break;
                    case SpriteHoldDependency.ColorAnimation:
                        cycle = ColorScheme.Cycle;
                        break;
                    case SpriteHoldDependency.VersionAnimation:
                        cycle = DependencyVersionAnimator.Cycle;
                        break;
                }
                if (cycle == CycleWhenFinish)
                {
                    Release();
                    FinishAction();
                }
            }

            LastSprite = Sprite;
        }
    }
}