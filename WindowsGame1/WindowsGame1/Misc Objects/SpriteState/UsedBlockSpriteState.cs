using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class UsedBlockSpriteState : SpriteStateKernel
    {
        public UsedBlockSpriteState()
        {
            SpriteList = new Collection<ISprite>{
                new UsedBlockSprite()
            };
        }


        public override ISprite Sprite
        {
            get { return FindSprite<UsedBlockSprite>(); }
        }
    }
}
