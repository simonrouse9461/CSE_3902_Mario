using System;

namespace SuperMario
{
    public class OneUpStateController : StateControllerKernel<StaticSpriteState<OneUpSprite>, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}