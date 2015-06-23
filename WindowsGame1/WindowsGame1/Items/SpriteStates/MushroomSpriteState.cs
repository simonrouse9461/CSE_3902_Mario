using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class MushroomSpriteState : ItemSpriteState
    {
        public MushroomSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new MushroomSprite(),
            };
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<MushroomSprite>();
            }
        }
    }

}
