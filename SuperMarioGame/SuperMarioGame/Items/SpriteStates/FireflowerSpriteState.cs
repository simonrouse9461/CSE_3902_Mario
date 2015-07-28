using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class FireflowerSpriteState : SpriteStateKernelNew<int>
    {
        public FireflowerSpriteState()
        {
            AddSprite<FireflowerSprite>();
        }
    }
}
