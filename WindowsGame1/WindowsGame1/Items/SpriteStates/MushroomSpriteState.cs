using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class MushroomSpriteState : ItemSpriteState
    {
        public MushroomSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new MushroomSprite(),
            };
        }

        public override ISprite Sprite
        {
            get
            {
                return FindSprite<MushroomSprite>();
            }
        }
    }

}
