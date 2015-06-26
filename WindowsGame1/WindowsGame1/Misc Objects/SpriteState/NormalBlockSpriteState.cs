﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        private StatusEnum Status;

        public NormalBlockSpriteState()
        {
            SpriteList = new Collection<ISprite> {
                new NormalBlockSprite(),
                new UsedBlockSprite(),
                //new DestroyedBlockSprite()
            };
            Status = StatusEnum.Normal;

        }


        public override ISprite Sprite
        {
            get
            {
                switch (Status)
                {
                    case StatusEnum.UsedBlock:
                        return FindSprite<UsedBlockSprite>();
                    default:
                        return FindSprite<NormalBlockSprite>();
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
