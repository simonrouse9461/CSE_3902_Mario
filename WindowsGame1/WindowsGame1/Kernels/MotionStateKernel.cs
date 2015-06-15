using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernel : IMotionState
    {
        protected Vector2 Position;

        protected Vector2 Velocity;

        protected Counter Timer;

        protected Dictionary<IMotion, bool> MotionList; 

        protected MotionStateKernel(Vector2 location)
        {
            Initialize();

            Position = location;
            Timer = Timer ?? new Counter();
            MotionList = MotionList ?? new Dictionary<IMotion, bool>();

            Reset();
        }

        protected abstract void Initialize();

        public void Reset()
        {
            Timer.Reset();
            foreach (var motion in MotionList)
            {
                motion.Key.Reset();
            }
        }

        public Vector2 CurrentPosition()
        {
            return Position;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public void Update()
        {
            RefreshState();

            if (Timer.Update())
            {
                foreach (var motion in MotionList)
                {
                    if (motion.Value)
                    {
                        motion.Key.Update();
                        Velocity = motion.Key.GetVelocity();
                        Position += Velocity;
                    }
                }
            }
        }

        protected abstract void RefreshState();
    }
}