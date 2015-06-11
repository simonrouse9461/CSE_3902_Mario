using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class MotionKernel : FunctionKernel<Vector2>
    {
        public MotionKernel(Func<int, Vector2> getValue = null, int period = 0) : base(getValue, period)
        {
            Initialize();
        }

        protected abstract void Initialize();
    }
}