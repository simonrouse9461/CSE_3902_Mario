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

        public void Adjust(Vector2 offset)
        {
            Position += offset;
        }

        protected MotionStateKernelNew()
        {
            Timer =  new Counter();
            Velocity = default(Vector2);
        }

        protected StatusSwitch<IMotion> FindMotion<T>(Func<T, T> filter = null) where T : IMotion, new()
        {
            if (filter == null) return MotionList.First(motion => motion.Content is T);

            T comparison = filter(new T());
            return MotionList.First(motion => comparison.SameVersion(motion.Content));
        }

        public void Reset()
        {
            Timer.Reset();
            foreach (var motion in MotionList)
            {
                motion.Reset(m => m.Reset());
            }
        }

        public void ResetHorizontal()
        {
            foreach (var motion in MotionList)
            {
                motion.Reset(m => m.ResetX());
            }
        }

        public void ResetVertical()
        {
            foreach (var motion in MotionList)
            {
                motion.Reset(m => m.ResetY());
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
                    if (motion.Status && !motion.Content.Finish)
                    {
                        motion.Content.Update();
                        Velocity += motion.Content.Velocity;
                    }
                }

                foreach (var motion in MotionList)
                {
                    if (!motion.Status || motion.Content.Finish)
                    {
                        motion.Toggle(false);
                        motion.Reset(m => m.Reset(Velocity));
                    }
                }

                Position += Velocity;
            }
        }
    }
}