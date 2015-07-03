using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class FloorBlockObject : ObjectKernel<BlockSpriteState, StaticMotionState>, IBlock
    {
        public FloorBlockObject() {
            SpriteState.FloorBlock();
        }
    }
}
