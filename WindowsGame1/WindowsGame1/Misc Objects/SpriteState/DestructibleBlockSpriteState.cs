using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class DestructibleBlockSpriteState : SpriteStateKernelNew
    {
        public DestructibleBlockSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>{
                new DestructibleBlockSprite(),
            };
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<DestructibleBlockSprite>();
            }
        }
    }
}
