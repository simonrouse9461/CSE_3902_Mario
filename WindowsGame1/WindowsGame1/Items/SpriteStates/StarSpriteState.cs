using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class StarSpriteState : ItemSpriteState
    {
        public StarSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new StarSprite(),
            };
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<StarSprite>();
            }
        }
    }
}