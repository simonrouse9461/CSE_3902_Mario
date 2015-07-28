using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class BushSpriteState : SpriteStateKernelNew<int>
    {
        public BushSpriteState()
        {
            AddSprite<BushHeadSprite>();
            AddSprite<BushBodySprite>();
            AddSprite<BushTailSprite>();
        }

        public void Head()
        {
            SetSprite<BushHeadSprite>();
        }

        public void Body()
        {
            SetSprite<BushBodySprite>();
        }

        public void Tail()
        {
            SetSprite<BushTailSprite>();
        }
    }
}
