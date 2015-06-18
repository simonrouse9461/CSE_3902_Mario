using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MushroomSpriteState : ItemSpriteState
    {
        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new MushroomSprite(),
            };
        }

        public override ISprite Sprite
        {
            get { return SpriteList[0]; }
        }
    }

}
