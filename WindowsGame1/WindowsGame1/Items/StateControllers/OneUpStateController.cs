using System;

namespace WindowsGame1
{
    public class OneUpStateController : StateControllerKernel<OneUpSpriteState, OneUpMotionState>
    {

        
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}