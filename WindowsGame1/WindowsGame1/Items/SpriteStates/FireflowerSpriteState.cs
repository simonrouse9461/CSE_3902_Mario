using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class FireflowerSpriteState : ItemSpriteState
    {
        public FireflowerSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new FireflowerSprite(),
            };
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<FireflowerSprite>();
            }
        }
    }
}
