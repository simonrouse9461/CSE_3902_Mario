using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class HillSpriteState : SpriteStateKernel
    {
        public HillSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new HillSprite()
            };
        }

        public override ISprite Sprite
        {
            get
            {
                return FindSprite<HillSprite>();
            }
        }
    }
}
