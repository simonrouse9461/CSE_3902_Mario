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

        private StatusEnum status;

        public StatusEnum Status
        {

            get { return status; }
            set { status = value; }
        }

        protected override void Initialize()
        {
            base.Initialize();

            SpriteList = new List<ISprite>{
                new QuestionBlockSprite(),
                new UsedBlockSprite(),
            };
            Status = StatusEnum.Animated;
        }
        public override ISprite ActiveSprite()
        {
            if (Status == StatusEnum.UsedBlock) { return SpriteList[1]; }
            else{
                return SpriteList[0];
            }
        }
    }
}
