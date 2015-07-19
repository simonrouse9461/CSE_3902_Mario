using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernelNew : IMotionState
    {
        protected Counter Timer { get; set; }
        protected Collection<StatusSwitch<IMotion>> MotionList { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public bool Frozen { get; private set; }

        public bool Static
        {
            get { return MotionList.All(m => !m.Status); }
        }

        protected MotionStateKernelNew()
        {
            Timer =  new Counter();
            Velocity = default(Vector2);
        }

        public StatusSwitch<IMotion> FindMotion<T>(T motion = null) where T : class, IMotion, new()
        {
            return motion == null
                ? MotionList.First(m => m.Content is T)
                : MotionList.First(m => motion.SameVersion(m.Content));
        }

        public void Adjust(Vector2 offset)
        {
            Position += offset;
        }

        public void Freeze()
        {
            foreach (var motion in MotionList) motion.Toggle(false);
            Frozen = true;
        }

        public void Restore()
        {
            Frozen = false;
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
                if ((int)motion.Content.Velocity.X != 0) motion.Content.ResetX();
            }
        }

        public void ResetVerticalVelocity()
        {
            foreach (var motion in MotionList)
            {
                if ((int)motion.Content.Velocity.Y != 0) motion.Content.ResetY();
            }
        }

        public void Update()
        {
            if (MotionList == null) return;
            if (Timer.Update())
            {
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
}