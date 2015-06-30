using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class IndestructibleBlockObject : ObjectKernel<BlockSpriteState, StaticMotionState>
    {
        public IndestructibleBlockObject()
        {
            SpriteState.Indestructible();
        }
    }
}
