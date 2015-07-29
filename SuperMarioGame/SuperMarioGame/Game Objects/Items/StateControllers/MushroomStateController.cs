using System;

namespace SuperMario
{
    public class MushroomStateController 
        : StateControllerKernel<StaticSpriteState<MushroomSprite>, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}