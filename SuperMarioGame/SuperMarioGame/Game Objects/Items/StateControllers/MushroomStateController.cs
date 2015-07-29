using System;

namespace SuperMario
{
    public class MushroomStateController 
        : StateControllerKernelNew<StaticSpriteState<MushroomSprite>, MushroomOneUpMotionState>
    {
        public void Generate()
        {
            MotionState.Generated();
        }
    }
}