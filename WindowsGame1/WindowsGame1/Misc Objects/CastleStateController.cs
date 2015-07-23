using System;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class CastleStateController : StateControllerKernelNew<CastleSpriteState, StaticMotionStateNew>
    {
        public void Castle()
        {
            SpriteState.SetCastle();
        }
    }
}
