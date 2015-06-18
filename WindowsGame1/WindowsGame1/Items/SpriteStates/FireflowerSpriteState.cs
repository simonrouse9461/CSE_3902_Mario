using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class FireflowerSpriteState : ItemSpriteState
    {

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new FireflowerSprite()
            };
        }

        public override ISprite ActiveSprite()
        {
            return SpriteList[0];
        }
    }
}
