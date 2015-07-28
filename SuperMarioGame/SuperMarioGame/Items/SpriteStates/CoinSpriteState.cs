using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CoinSpriteState : SpriteStateKernelNew<int>
    {
        public CoinSpriteState()
        {
            AddSprite<CoinSprite>();
        }
    }
}