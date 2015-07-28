using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class StarSpriteState : SpriteStateKernelNew<int>
    {
        public StarSpriteState()
        {
            AddSprite<StarSprite>();
        }
    }
}