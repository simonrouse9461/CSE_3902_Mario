using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernel : IMotionState
    {
        protected Counter Timer { get; set; }
        protected Collection<StatusSwitch<IMotion>> MotionList { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public void Adjust(Vector2 offset)
        {
            Position += offset;
        }

        protected MotionStateKernel()
        {
            Timer =  new Counter();
            Velocity = default(Vector2);
        }

        protected StatusSwitch<IMotion> FindMotion<T>(Func<T, bool> filter = null) where T : IMotion
        {
            filter = filter ?? (motion => true);
            return MotionList.First(motion => motion.Content is T && filter((T)motion.Content));
        }

        public void Reset()
        {
            Timer.Reset();
            foreach (var motion in MotionList)
            {
                motion.Reset(m => m.Reset());
            }
        }

        private void RestoreMotionStatus()
        {
            foreach (var motion in MotionList)
            {
                motion.Toggle(false);
            }
        }

        private void UpdateMotion()
        {
            Velocity = default(Vector2);

            foreach (var motion in MotionList)
            {
                if (motion.Status && !motion.Content.Finish)
                {
                    motion.Content.Update();
                    Velocity += motion.Content.Velocity;
                }
                else
                {
                    motion.Reset(m => m.Reset(Velocity));
                }
            }

            Position += Velocity;
        }

        // This method is used to turn on motion switches base on current state.
        protected abstract void RefreshMotionStatus();

        // This method is used to automatically restore states to their default value after update.
        protected abstract void SetToDefaultState();

        public void Update()
        {
            if (MotionList == null) return;
            if (Timer.Update())
            {
                RestoreMotionStatus();
                RefreshMotionStatus();
                UpdateMotion();
                SetToDefaultState();
            }
        }
    }
}