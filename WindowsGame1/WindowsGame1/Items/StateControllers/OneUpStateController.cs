using System;

namespace WindowsGame1
{
    public class OneUpStateController : StateControllerKernel<OneUpSpriteState, MushroomMotionState>
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