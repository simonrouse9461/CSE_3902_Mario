using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class IndestructibleBlockSpriteState : SpriteStateKernelNew
    {
        public IndestructibleBlockSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>{
                new IndestructibleBlockSprite()
            };
        }

        public override ISpriteNew Sprite
        {
            get { return FindSprite<IndestructibleBlockSprite>(); }
        }
    }
}
