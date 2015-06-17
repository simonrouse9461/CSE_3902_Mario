using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{

    public class _1up : ObjectKernel<_1upSpriteState, RightMotionState>
    {
        protected override void Initialize()
        {
            SpriteState = new _1upSpriteState();
            MotionState = new RightMotionState();

        }
   }
}
