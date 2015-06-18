using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class QuestionBlockSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Animated,
            UsedBlock
        }

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>{
                new QuestionBlockSprite(),
                new UsedBlockSprite(),
            };
            Status = StatusEnum.Animated;
        }
        public override ISprite Sprite
        {
            get { return Status == StatusEnum.UsedBlock ? SpriteList[1] : SpriteList[0]; }
        }

        public void UsedBlock()
        {
            Status = StatusEnum.UsedBlock;
        }

        public void Animated()
        {
            Status = StatusEnum.Animated;
        }
    }
}
