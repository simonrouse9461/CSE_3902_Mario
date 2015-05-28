using System;

namespace WindowsGame1
{
    public class SpriteAnimation : FunctionKernel<int>
    {
        public SpriteAnimation(Func<int, int> getValue = null, int period = 0) : base(getValue, period) { }
    }
}