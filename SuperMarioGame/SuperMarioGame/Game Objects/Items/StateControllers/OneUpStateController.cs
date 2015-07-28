using System;

namespace SuperMario
{
    public class OneUpStateController : StateControllerKernelNew<OneUpSpriteState, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}