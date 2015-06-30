using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class CoinSpriteState : ItemSpriteState
    {
        public CoinSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new CoinSprite(),
            };
            ChangeSpriteFrequency(10);
        }

        public override ISprite Sprite
        {
            get
            {
                return FindSprite<CoinSprite>();
            }
        }
    }
}