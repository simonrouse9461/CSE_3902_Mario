using System.Collections.Generic;

namespace WindowsGame1
{
    public class CoinSpriteState : ItemSpriteState
    {
        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new CoinSprite(), //0
            };
        }

        public override ISprite Sprite
        {
            get { return SpriteList[0]; }
        }
    }
}