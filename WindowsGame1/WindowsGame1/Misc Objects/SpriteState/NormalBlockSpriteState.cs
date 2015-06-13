using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class NormalBlockSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Normal,
            Destroyed,
            UsedBlock
        }

        private StatusEnum status;

        public StatusEnum Status
        {
            get { return status; }
            set { status = value; }
        }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>{
                new NormalBlockSprite(),
                new UsedBlockSprite(),
                new DestroyedBlockSprite()
            };
            Status = StatusEnum.Normal;
        }

        public override ISprite ActiveSprite()
        {
            if (Status == StatusEnum.Normal)
            {
                return SpriteList[0];
            }
            else if (Status == StatusEnum.UsedBlock)
            {
                return SpriteList[1];
            }
            else
            {
                return SpriteList[2];
            }
        }
    }
}
