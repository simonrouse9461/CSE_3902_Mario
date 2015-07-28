using System;

namespace SuperMario
{
    public class MushroomStateController : StateControllerKernelNew<MushroomSpriteState, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}