using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class MushroomSpriteState : SpriteStateKernelNew<int>
    {
        public MushroomSpriteState()
        {
            AddSprite<MushroomSprite>();
        }
    }

}
