using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class CastleStateController : StateControllerKernelNew<CastleSpriteState, StaticMotionStateNew>
    {
        public void Castle()
        {
            SpriteState.SetCastle();
        }
    }
}
