using System;

namespace SuperMario
{
    public class FireflowerStateController : StateControllerKernelNew<StaticSpriteState<FireflowerSprite>, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}