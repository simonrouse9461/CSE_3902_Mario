using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class IndestructibleBlockMotionState : MotionStateKernel
    {
        public IndestructibleBlockMotionState(Vector2 location) : base(location) { }

        protected override void Initialize()
        {
            MotionList = new Dictionary<MotionKernel, bool>
            {
                {new NullMotion(), false }
            };
        }
    }
}
