using System;

namespace MarioGame
{
    public class MushroomStateController : StateControllerKernel<MushroomSpriteState, MushroomMotionState>
    {

        public void Generate()
        {
            MotionState.Generated();
        }
    }
}