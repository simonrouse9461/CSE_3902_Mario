using System;

namespace SuperMario
{
    public class OneUpStateController : StateControllerKernelNew<StaticSpriteState<OneUpSprite>, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}