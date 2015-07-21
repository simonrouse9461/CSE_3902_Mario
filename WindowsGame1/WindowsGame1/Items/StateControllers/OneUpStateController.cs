using System;

namespace MarioGame
{
    public class OneUpStateController : StateControllerKernel<OneUpSpriteState, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}