using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Mushroom : ObjectKernel<MushroomSpriteState, RightMotionState>
    {
        protected override void Initialize()
        {
            SpriteState = new MushroomSpriteState();
            MotionState = new RightMotionState();
        }
    }
}
