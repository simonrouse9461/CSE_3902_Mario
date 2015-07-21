using System;

namespace MarioGame
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