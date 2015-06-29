using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class HiddenBlockSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Hidden,
            UsedBlock
        }

        private StatusEnum Status;

        public HiddenBlockSpriteState()
        {
            SpriteList = new Collection<ISprite>{
                new HiddenBlockSprite(),
                new UsedBlockSprite(),
            };
            Status = StatusEnum.Hidden;
        }


        public override ISprite Sprite
        {
            get {
                if (Status == StatusEnum.UsedBlock)
                {
                    return FindSprite<UsedBlockSprite>();
                }
                else
                {
                    return FindSprite<HiddenBlockSprite>();
                }
            }
        }

        public void HiddenToUsedBlock()
        {
            Status = StatusEnum.UsedBlock;
        }

        public void HiddenBlock()
        {
            Status = StatusEnum.Hidden;
        }
    }
}
