using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class HillSpriteState : SpriteStateKernelNew
    {
        public HillSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new HillSprite()
            };
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<HillSprite>();
            }
        }
    }
}
