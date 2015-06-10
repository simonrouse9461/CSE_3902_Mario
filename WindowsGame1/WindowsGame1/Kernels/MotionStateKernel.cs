using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionStateKernel : IMotionState
    {
        private Vector2 Location;

        private Counter Timer;

        protected Dictionary<ObjectMotion, bool> MotionList; 

        protected MotionStateKernel(Vector2 location, int frequency = 10)
        {
            Reset(location, frequency);
        }

        protected abstract void Initialize();

        public Vector2 CurrentLocation()
        {
            return Location;
        }

        public void Reset(Vector2 location, int frequency = 10)
        {
            Timer = new Counter(frequency);
            Location = location;
            Initialize();
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
                        Location += motion.Key.GetValue();
                    }
                }
            }
        }
    }
}