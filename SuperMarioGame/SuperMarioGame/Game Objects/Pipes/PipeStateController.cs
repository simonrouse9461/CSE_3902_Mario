using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class PipeStateController : StateControllerKernelNew<GreenPipeSpriteState, StaticMotionStateNew>
    {
        public bool Warp;

        public void isWarp()
        {
            Warp = true;
        }

        public void SmallWarpPipe()
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
