using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class _1UpSpriteState : ItemSpriteState
    {
        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new _1UpSprite()
            };
        }

        public override ISprite Sprite
        {
            get { return SpriteList[0]; }
        }
    }
}
