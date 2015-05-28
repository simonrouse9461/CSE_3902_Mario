using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class ObjectMotion : FunctionKernel<Vector2>
    {
        public ObjectMotion(Func<int, Vector2> getValue = null, int period = 0) : base(getValue, period) { }
    }
}