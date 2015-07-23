using System;

namespace SuperMario
{
    public class MushroomStateController : StateControllerKernel<MushroomSpriteState, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}