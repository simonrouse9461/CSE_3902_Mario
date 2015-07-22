using System;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class CastleStateController : StateControllerKernelNew<CastleSpriteState, StaticMotionState>
    {

        public void Castle()
        {
            SpriteState.SetCastle();
        }
    }
}
