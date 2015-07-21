using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class BlockKernel : ObjectKernelNew<BlockStateController>, IBlock
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
