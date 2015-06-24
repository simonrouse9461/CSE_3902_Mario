using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class _1UpSpriteState : ItemSpriteState
    {
        public _1UpSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new _1UpSprite()
            };
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<_1UpSprite>();
            }
        }
    }
}
