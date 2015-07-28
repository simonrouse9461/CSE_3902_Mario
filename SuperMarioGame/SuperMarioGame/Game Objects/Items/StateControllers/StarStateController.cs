using System;

namespace SuperMario
{
    public class StarStateController : StateControllerKernelNew<StarSpriteState, StarMotionState>
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