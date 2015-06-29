using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class IndestructibleBlockObject : ObjectKernelNew<BlockSpriteState, BlockMotionState>
    {
        
        public IndestructibleBlockObject()
        {
            SpriteState = new BlockSpriteState();
            MotionState = new BlockMotionState();
            State.SpriteState.Indestructible();
            
        }

        protected override void SyncState()
        {

        }

    }
}
