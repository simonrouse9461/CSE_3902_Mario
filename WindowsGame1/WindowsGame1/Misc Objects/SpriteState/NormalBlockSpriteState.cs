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

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite> {
                new NormalBlockSprite(),
                new UsedBlockSprite(),
                new DestroyedBlockSprite()
            };

            Status = StatusEnum.Normal;
        }

        public override ISprite Sprite
        {
            get
            {
                switch (Status)
                {
                    case StatusEnum.Normal:
                        return SpriteList[0];
                    case StatusEnum.UsedBlock:
                        return SpriteList[1];
                    default:
                        return SpriteList[2];
                }
            }
        }

        public void NormalBlock()
        {
            Status = StatusEnum.Normal;
        }

        public void DestroyedBlock()
        {
            Status = StatusEnum.Destroyed;
        }

        public void NormalUsedBlock()
        {
            Status = StatusEnum.UsedBlock;
        }
    }
}
