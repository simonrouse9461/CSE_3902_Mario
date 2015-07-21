using System;

namespace MarioGame
{
    public class FireflowerStateController : StateControllerKernel<FireflowerSpriteState, MushroomMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}