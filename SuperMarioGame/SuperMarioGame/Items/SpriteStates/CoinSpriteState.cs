using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CoinSpriteState : SpriteStateKernel
    {
        public CoinSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new CoinSprite(),
            };
            ChangeSpriteFrequency(10);
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<CoinSprite>();
            }
        }
    }
}