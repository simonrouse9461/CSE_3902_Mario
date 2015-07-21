using System;

namespace MarioGame
{
    public class OneUpStateController : StateControllerKernel<OneUpSpriteState, OneUpMotionState>
    {

        
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}