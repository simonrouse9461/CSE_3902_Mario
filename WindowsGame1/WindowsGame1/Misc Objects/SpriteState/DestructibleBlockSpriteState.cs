using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class DestructibleBlockSpriteState : SpriteStateKernelNew
    {
        public enum StatusEnum{
            Destructible,
            Destroyed
        }

        private StatusEnum Status;

        public DestructibleBlockSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>{
                new DestructibleBlockSprite(),
                //new DestroyedBlockSprite()
            };
            Status = StatusEnum.Destructible;
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<DestructibleBlockSprite>();
            }
        }

        public void DestructibleDestroyed()
        {
            Status = StatusEnum.Destroyed;
        }

        public void DestructibleBlock()
        {
            Status = StatusEnum.Destructible;
        }
    }
}
