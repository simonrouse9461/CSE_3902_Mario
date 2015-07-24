using System;

namespace SuperMario
{
    public class OneUpStateController : StateControllerKernel<OneUpSpriteState, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}