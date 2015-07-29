using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public abstract class SpriteStateKernel<TVersion> : ISpriteState where TVersion : IConvertible
    {
        protected ICore Core;
        protected Counter ColorTimer { get; set; }
        protected Counter SpriteTimer { get; set; }
        protected Counter VersionTimer { get; set; }

        private Collection<ISprite> SpriteList { get; set; }
        private ISprite _sprite;
        public ISprite Sprite
        {
            get { return _sprite; }
            set { if (!IsHeld) _sprite = value; }
        }
        private ISprite LastSprite { get; set; }

        private Dictionary<IConvertible, PeriodicFunction<Color>> ColorSchemeList { get; set; }
        private PeriodicFunction<Color> ColorScheme { get; set; }
        public Color Color
        {
            get
            {
                var defaultColor = IsHidden ? Color.Transparent : Color.White;
                return ColorScheme == null ? defaultColor : ColorScheme.Value;
            }
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
        public bool IsHeld { get; private set; }
        public bool IsFrozen { get; private set; }
        public bool IsHidden { get; private set; }
        private bool HoldOrientation { get; set; }
        private int CycleWhenFinish { get; set; }
        private Action FinishAction { get; set; }
        

        public Orientation Orientation { get; private set; }
        public bool IsLeft { get { return Orientation == Orientation.Left; } }
        public bool IsRight { get { return Orientation == Orientation.Right; } }
        public bool IsDefaultSprite { get { return Orientation == Orientation.Default; } }

        protected SpriteStateKernel()
        {
            SpriteList = new Collection<ISprite>();
            ColorSchemeList = new Dictionary<IConvertible, PeriodicFunction<Color>>();
            VersionAnimatorList = new Dictionary<IConvertible, PeriodicFunction<TVersion>>();
            ActiveVersionAnimatorStack = new LinkedList<PeriodicFunction<TVersion>>();
            SpriteTimer = new Counter();
            ColorTimer = new Counter();
            VersionTimer = new Counter();
            FaceDefault();
        }

        public void SetCore(ICore c)
        {
            Core = c;
        }

        public void PassSprite(ISprite sprite)
        {
            _sprite = sprite;
            SpriteList.Add(sprite);
        }

        protected void AddSprite<T>() where T : ISprite, new()
        {
            if (SpriteList.Any(s => s is T)) return;
            SpriteList.Add(new T());
        }

        protected ISprite FindSprite<T>() where T : ISprite
        {
            return SpriteList.First(sprite => sprite is T);
        }

        protected void SetSprite<T>() where T : ISprite
        {
            Sprite = FindSprite<T>();
        }

        protected bool IsSprite<T>() where T : ISprite
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
            IsHeld = true;
            HoldDependency = SpriteHoldDependency.Updates;
            if (timer > 0) Core.DelayCommand(() =>
            {
                Release();
                action();
            }, () => HoldDependency == SpriteHoldDependency.Updates, timer);
        }

        public void HoldTillFinish(bool holdOrientation, SpriteHoldDependency dependency, int cycle, Action action = null)
        {
            if (dependency == SpriteHoldDependency.Updates)
            {
                Hold(holdOrientation, cycle, action);
                return;
            }
            HoldOrientation = holdOrientation;
            IsHeld = true;
            HoldDependency = dependency;
            DependencyVersionAnimator = EffectiveVersionAnimator;
            CycleWhenFinish = cycle;
            FinishAction = action ?? (() => { });
        }

        public void HoldTillFinish(bool holdOrientation, SpriteHoldDependency dependency, Action action = null)
        {
            HoldTillFinish(holdOrientation, dependency, 1, action);
        }

        public void HoldTillFinish(bool holdOrientation, int cycle, Action action = null)
        {
            HoldTillFinish(holdOrientation, SpriteHoldDependency.SpriteAnimation, cycle, action);
        }

        public void HoldTillFinish(bool holdOrientation, Action action = null)
        {
            HoldTillFinish(holdOrientation, SpriteHoldDependency.SpriteAnimation, 1, action);
        }

        public void Release()
        {
            IsHeld = false;
            HoldOrientation = false;
            CycleWhenFinish = 0;
        }

        public void Freeze(int timer = 0)
        {
            IsFrozen = true;
            if (timer != 0) Core.DelayCommand(Resume, timer);
        }

        public void Resume()
        {
            IsFrozen = false;
        }

        public void Load(ContentManager content)
        {
            foreach (var sprite in SpriteList)
            {
                sprite.Load(content);
            }
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public void Show()
        {
            IsHidden = false;
        }

        public void SetSpriteFrequency(int frequency)
        {
            if (SpriteTimer.Frequency == frequency) return;
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
            if (SpriteTimer.Update() && !IsFrozen) Sprite.Update();
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

            if (IsHeld)
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
                if (cycle >= CycleWhenFinish)
                {
                    Release();
                    FinishAction();
                }
            }

            LastSprite = Sprite;
        }
    }
}