using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class CoinSpriteState : ItemSpriteState
    {
        public CoinSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new CoinSprite(),
            };
            ChangeFrequency(10);
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<CoinSprite>();
            }
        }
    }
}