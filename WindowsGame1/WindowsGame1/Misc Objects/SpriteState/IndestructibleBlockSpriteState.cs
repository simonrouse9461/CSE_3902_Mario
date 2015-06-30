using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class IndestructibleBlockSpriteState : SpriteStateKernel
    {
        public IndestructibleBlockSpriteState()
        {
            SpriteList = new Collection<ISprite>{
                new IndestructibleBlockSprite()
            };
        }

        public override ISprite Sprite
        {
            get { return FindSprite<IndestructibleBlockSprite>(); }
        }
    }
}
