using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class BushSpriteState : SpriteStateKernelNew<int>
    {
        public BushSpriteState()
        {
            AddSprite<BushSprite>();
            SetSprite<BushSprite>();
        }
    }
}
