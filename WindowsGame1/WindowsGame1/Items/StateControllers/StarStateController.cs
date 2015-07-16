using System;

namespace WindowsGame1
{
    public class StarStateController : StateControllerKernel<StarSpriteState, StarMotionState>
    {

        public void Generate()
        {
            MotionState.Generated();
        }
        public void Bouncing()
        {
            MotionState.Bouncing();
        }
    }
}