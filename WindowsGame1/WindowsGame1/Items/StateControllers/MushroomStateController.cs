using System;

namespace WindowsGame1
{
    public class MushroomStateController : StateControllerKernel<MushroomSpriteState, MushroomMotionState>
    {

        public void Generate()
        {
            MotionState.Generated();
        }

        public void StartMoving()
        {
            MotionState.Moving();
        }
    }
}