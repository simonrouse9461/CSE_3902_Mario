using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class HillSpriteState : SpriteStateKernel<int>
    {
        public HillSpriteState()
        {
            AddSprite<SmallHillSprite>();
            AddSprite<LargeHillSprite>();
        }

        public void Small()
        {
            SetSprite<SmallHillSprite>();
        }

        public void Large()
        {
            SetSprite<LargeHillSprite>();
        }
    }
}
