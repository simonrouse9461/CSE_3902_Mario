using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class UsedBlockSpriteState : SpriteStateKernelNew
    {
        public UsedBlockSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>{
                new UsedBlockSprite()
            };
        }


        public override ISpriteNew Sprite
        {
            get { return FindSprite<UsedBlockSprite>(); }
        }
    }
}
