using System;

namespace SuperMario
{
    public class FireflowerStateController : StateControllerKernel<StaticSpriteState<FireflowerSprite>, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}