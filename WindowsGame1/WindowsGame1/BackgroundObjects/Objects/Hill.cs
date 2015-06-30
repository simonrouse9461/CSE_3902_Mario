using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Hill : ObjectKernel<HillSpriteState, StaticMotionState>
    {
        // make it not solid so that anything can pass through it
        public override bool Solid
        {
            get { return false; }
        }
    }
}
