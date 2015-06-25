using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class GreenPipeObject : ObjectKernelNew<GreenPipeSpriteState, GreenPipeMotionState>
    {
        public GreenPipeObject() {

            SpriteState = new GreenPipeSpriteState();
            MotionState = new GreenPipeMotionState();
        }
        
        protected override void SyncState()
        {

        }
    }

}
