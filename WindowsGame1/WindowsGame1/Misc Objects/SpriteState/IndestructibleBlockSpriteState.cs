using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class IndestructibleBlockSpriteState : SpriteStateKernelNew
    {

        private enum StatusEnum
        {
            Indestructible
        }

        private StatusEnum Status;

        public IndestructibleBlockSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>{
                new IndestructibleBlockSprite()
            };
            Status = StatusEnum.Indestructible;
        }

        public override ISpriteNew Sprite
        {
            get { return FindSprite<IndestructibleBlockSprite>(); }
        }
    }
}
