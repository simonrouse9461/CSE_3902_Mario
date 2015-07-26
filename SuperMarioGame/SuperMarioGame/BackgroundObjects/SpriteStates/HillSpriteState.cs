using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class HillSpriteState : SpriteStateKernelNew<int>
    {
        public HillSpriteState()
        {
            AddSprite<HillSprite>();
            SetSprite<HillSprite>();
        }
    }
}
