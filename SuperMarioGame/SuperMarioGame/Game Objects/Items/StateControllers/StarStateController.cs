using System;

namespace SuperMario
{
    public class StarStateController : StateControllerKernelNew<StaticSpriteState<StarSprite>, StarMotionState>
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