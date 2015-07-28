using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class OneUpSpriteState : SpriteStateKernelNew<int>
    {
        public OneUpSpriteState()
        {
            AddSprite<OneUpSprite>();
        }
    }
}
