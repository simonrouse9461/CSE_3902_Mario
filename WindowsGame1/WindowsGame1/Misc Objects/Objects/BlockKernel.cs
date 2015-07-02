using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class BlockKernel : ObjectKernel<BlockSpriteState, BlockMotionState>, IBlock
    {
        public BlockKernel()
        {
            SpriteState.Indestructible();
        }

        
    }
}
