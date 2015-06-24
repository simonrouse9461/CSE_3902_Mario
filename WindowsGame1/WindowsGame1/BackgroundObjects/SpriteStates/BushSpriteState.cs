using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class BushSpriteState :SpriteStateKernelNew
    {
        public BushSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new BushSprite()
            };
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<BushSprite>();
            }
        }
    }
}
