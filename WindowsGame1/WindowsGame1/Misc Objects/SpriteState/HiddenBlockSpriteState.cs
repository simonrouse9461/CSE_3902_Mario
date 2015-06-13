using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class HiddenBlockSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Hidden,
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
                new HiddenBlockSprite(),
                new UsedBlockSprite(),
            };
            Status = StatusEnum.Hidden;
        }

        public override ISprite ActiveSprite()
        {
            if (Status == StatusEnum.Hidden)
            {
                return SpriteList[0];
            }
            else
            {
                return SpriteList[1];
            }
        }

    }
}
