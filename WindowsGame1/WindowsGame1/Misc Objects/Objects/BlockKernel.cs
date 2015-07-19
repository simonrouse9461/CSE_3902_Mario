using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class BlockKernel : ObjectKernel<BlockStateController>, IBlock
    {
        public BlockKernel()
        {
            StateController.IndestructibleBlock();
        }

        public bool Hit
        {
            get
            {
                return StateController.MotionState.isHit;
            }
        }
    }
}
