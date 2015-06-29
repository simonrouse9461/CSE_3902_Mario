using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class BushSpriteState :SpriteStateKernel
    {
        public BushSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new BushSprite()
            };
        }

        public override ISprite Sprite
        {
            get
            {
                return FindSprite<BushSprite>();
            }
        }
    }
}
