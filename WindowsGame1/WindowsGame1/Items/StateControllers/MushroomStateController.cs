using System;

namespace MarioGame
{
    public class MushroomStateController : StateControllerKernel<MushroomSpriteState, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}