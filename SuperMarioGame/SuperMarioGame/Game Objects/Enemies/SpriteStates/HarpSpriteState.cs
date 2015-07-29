using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class HarpSpriteState : SpriteStateKernel<int>
    {
        public HarpSpriteState()
        {
            AddSprite<HarpSprite>();
            SetSprite<HarpSprite>();
        }
    }
}