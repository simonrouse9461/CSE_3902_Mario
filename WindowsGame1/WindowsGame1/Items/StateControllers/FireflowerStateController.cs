using System;

namespace WindowsGame1
{
    public class FireflowerStateController : StateControllerKernel<FireflowerSpriteState, MushroomMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}