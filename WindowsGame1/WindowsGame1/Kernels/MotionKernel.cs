using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionKernel : PeriodicFunction<Vector2>
    {
        public MotionKernel(int period = 0)
        {
            Initialize();
        }

        protected abstract void Initialize();

    }
}