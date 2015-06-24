﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernelNew : IMotionState
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public void Adjust(Vector2 offset)
        {
            Position += offset;
        }

        protected Counter Timer { get; set; }
        protected List<StatusSwitch<IMotion>> MotionList { get; set; }

        protected MotionStateKernelNew()
        {
            Timer =  new Counter();
            Velocity = default(Vector2);
        }

        protected StatusSwitch<IMotion> FindMotion<T>() where T : IMotion
        {
            return MotionList.First(motion => motion.Content is T);
        }

        public void Reset()
        {
            Timer.Reset();
            MotionList.ForEach(motion => motion.Reset(m => m.Reset()));
        }

        private void RestoreMotionStatus()
        {
            MotionList.ForEach(motion => motion.Toggle(false));
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