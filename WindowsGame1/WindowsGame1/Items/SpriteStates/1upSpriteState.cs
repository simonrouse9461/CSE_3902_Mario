using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class _1UpSpriteState : SpriteStateKernel
    {
        public _1UpSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new _1UpSprite()
            };
        }

        public override ISprite Sprite
        {
            get
            {
                return FindSprite<_1UpSprite>();
            }
        }
    }
}
