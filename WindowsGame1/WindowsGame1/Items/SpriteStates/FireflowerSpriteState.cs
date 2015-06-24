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
            ChangeFrequency(10);
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
