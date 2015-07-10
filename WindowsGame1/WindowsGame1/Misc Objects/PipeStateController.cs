using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class PipeStateController : StateControllerKernel<GreenPipeSpriteState, StaticMotionState>
    {

        public void WarpPipe()
        {
            SpriteState.SecretPipe();
        }

        public void SmallPipe()
        {
            SpriteState.SmallPipe();
        }

        public void TallPipe()
        {
            SpriteState.TallPipe();
        }

        public void MediumPipe()
        {
            SpriteState.MediumPipe();
        }
    }
}
