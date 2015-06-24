using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class UsedBlockSpriteState : SpriteStateKernelNew
    {
        public enum StatusEnum
        {
            Used
        }

        private StatusEnum Status;

        public UsedBlockSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>{
                new UsedBlockSprite()
            };
            Status = StatusEnum.Used;
        }


        public override ISpriteNew Sprite
        {
            get { 
                return FindSprite<UsedBlockSprite>(); }
        }
    }
}
