using System;

namespace SuperMario
{
    public class FireflowerStateController : StateControllerKernelNew<FireflowerSpriteState, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}