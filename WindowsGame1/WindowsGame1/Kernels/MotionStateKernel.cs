using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernel : IMotionState
    {
        protected Vector2 Position;

        protected Counter Timer;

        protected Dictionary<MotionKernel, bool> MotionList; 

        protected MotionStateKernel(Vector2 location)
        {
            Initialize(location);
            Reset();
        }

        protected virtual void Initialize(Vector2 location)
        {
            Position = location;
            Timer = Timer ?? new Counter();
            MotionList = MotionList ?? new Dictionary<MotionKernel, bool>();
        }

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
            if (Timer.Update())
            {
                foreach (var motion in MotionList)
                {
                    if (motion.Value)
                    {
                        motion.Key.Update();
                        Position += motion.Key.GetValue();
                    }
                }
            }
        }
    }
}