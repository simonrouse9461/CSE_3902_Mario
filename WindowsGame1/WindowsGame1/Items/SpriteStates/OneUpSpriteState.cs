using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class OneUpSpriteState : SpriteStateKernel
    {
        public OneUpSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new OneUpSprite()
            };
        }

        public override ISprite Sprite
        {
            get
            {
                return FindSprite<OneUpSprite>();
            }
        }
    }
}
