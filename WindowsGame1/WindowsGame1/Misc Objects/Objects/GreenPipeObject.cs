using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class GreenPipeObject : ObjectKernel<GreenPipeSpriteState, GreenPipeMotionState>
    {
        protected override void Initialize()
        {
            SpriteState = new GreenPipeSpriteState();
            MotionState = new GreenPipeMotionState();
        }
        protected override void SyncState()
        {

        }
    }

}
