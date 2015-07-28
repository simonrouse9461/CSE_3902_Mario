using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class FloatingCoinSpriteState : SpriteStateKernelNew<int>
    {

        public FloatingCoinSpriteState()
        {
            AddSprite<FloatingCoinSprite>();
        }        
    }
}
