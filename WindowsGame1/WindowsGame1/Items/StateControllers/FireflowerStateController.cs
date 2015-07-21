using System;

namespace MarioGame
{
    public class FireflowerStateController : StateControllerKernel<FireflowerSpriteState, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}