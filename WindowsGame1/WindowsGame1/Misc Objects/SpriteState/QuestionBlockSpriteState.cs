using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class QuestionBlockSpriteState : SpriteStateKernel
    {
        private enum StatusEnum
        {
            Animated,
            UsedBlock
        }

        private StatusEnum Status;

        public QuestionBlockSpriteState()
        {
            SpriteList = new Collection<ISprite>{
                new QuestionBlockSprite(),
                new UsedBlockSprite(),
            };
            Status = StatusEnum.Animated;
            ChangeSpriteFrequency(10);
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
                    return FindSprite<QuestionBlockSprite>();
                }
            }
        }

        public void UsedBlock()
        {
            Status = StatusEnum.UsedBlock;
        }

        //public override void Animated()
        //{
        //    Status = StatusEnum.Animated;
        //}
    }
}
