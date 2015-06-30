using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class IndestructibleBlockObject : ObjectKernel<BlockSpriteState, BlockMotionState>
    {
        
        public IndestructibleBlockObject()
        {
            SpriteState = new BlockSpriteState();
            MotionState = new BlockMotionState();
            SpriteState.Indestructible();
            
        }

        protected override void SyncState()
        {

        }

    }
}
