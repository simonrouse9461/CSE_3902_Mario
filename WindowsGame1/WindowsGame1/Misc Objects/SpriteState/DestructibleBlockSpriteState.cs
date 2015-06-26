using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class DestructibleBlockSpriteState : SpriteStateKernel
    {
        public DestructibleBlockSpriteState()
        {
            SpriteList = new Collection<ISprite>{
                new DestructibleBlockSprite(),
            };
        }

        public override ISprite Sprite
        {
            get
            {
                return FindSprite<DestructibleBlockSprite>();
            }
        }
    }
}
