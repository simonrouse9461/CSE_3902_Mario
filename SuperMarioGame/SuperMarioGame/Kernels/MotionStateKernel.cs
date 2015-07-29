using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public abstract class MotionStateKernel : IMotionState
    {
        private ICore Core { get; set; }
        private Counter Timer { get; set; }
        private Collection<StatusSwitch<IMotion>> MotionList { get; set; }

        public Vector2 Position { get; private set; }
        public Vector2 LastSetPosition { get; set; }
        public Vector2 Velocity { get; set; }
        public bool IsFrozen { get; private set; }

        public void SetCore(ICore c)
        {
            Core = c;
        }

        public bool IsStatic
        {
            get { return MotionList.All(m => !m.Status); }
        }

        protected MotionStateKernel()
        {
            Timer = new Counter();
            Velocity = default(Vector2);
            MotionList = new Collection<StatusSwitch<IMotion>>();
        }

        protected void AddMotion<T>(T motion = null) where T : class, IMotion, new()
        {
            motion = motion ?? new T();
            MotionList.Add(new StatusSwitch<IMotion>(motion));
        }

        protected StatusSwitch<IMotion> FindMotion<T>(T motion = null) where T : class, IMotion, new()
        {
            return motion == null
                ? MotionList.First(m => m.Content is T)
                : MotionList.First(m => motion.SameVersion(m.Content));
        }

        protected void TurnOnMotion<T>(T motion = null) where T : class, IMotion, new()
        {
            FindMotion(motion).Toggle(true);
        }

        protected void TurnOffMotion<T>(T motion = null) where T : class, IMotion, new()
        {
            FindMotion(motion).Toggle(false);
        }

        protected void ResetMotion<T>(T motion = null) where T : class, IMotion, new()
        {
            FindMotion(motion).Content.Reset();
        }

        protected bool CheckMotion<T>(T motion = null) where T : class, IMotion, new()
        {
            return FindMotion(motion).Status;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
            LastSetPosition = position;
        }

        public void AdjustPosition(Vector2 offset)
        {
            Position += offset;
        }

        public void Freeze(int timer = 0)
        {
            IsFrozen = true;
            if (timer != 0) Core.DelayCommand(Restore, timer);
        }

        public void Restore()
        {
            IsFrozen = false;
        }

        public void Reset()
        {
            Timer.Reset();
            foreach (var motion in MotionList)
            {
                motion.Reset(m => m.Reset());
            }
        }

        public void ResetHorizontalVelocity()
        {
            foreach (var motion in MotionList)
            {
                if ((int) motion.Content.Velocity.X != 0) motion.Content.ResetX();
            }
        }

        public void ResetVerticalVelocity()
        {
            foreach (var motion in MotionList)
            {
                if ((int) motion.Content.Velocity.Y != 0) motion.Content.ResetY();
            }
        }

        public void Update()
        {
            if (IsFrozen) return;
            if (MotionList == null) return;
            if (!Timer.Update()) return;

            Velocity = default(Vector2);

            foreach (var motion in MotionList)
            {
                if (motion.Content.Finish) motion.Toggle(false);
                if (motion.Status)
                {
                    motion.Content.Update();
                    Velocity += motion.Content.Velocity;
                }
                else motion.Reset(m => m.Reset());
            }

            foreach (var motion in MotionList)
            {
                motion.Content.SetCurrentVelocity(Velocity);
                if (!motion.Status) motion.Reset(m => m.SetInitialVelocity(Velocity));
            }

            Position += Velocity;
        }
    }
}