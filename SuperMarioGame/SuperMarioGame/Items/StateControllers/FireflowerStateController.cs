using System;

namespace SuperMario
{
    public class FireflowerStateController : StateControllerKernel<FireflowerSpriteState, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}