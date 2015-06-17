using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class CloudSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Still
        }

        private StatusEnum status;

        public StatusEnum Status
        {
            get { return status; }
            set { status = value; }
        }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new CloudSprite()
            };

            Status = StatusEnum.Still;
        }

        public override ISprite ActiveSprite()
        {
            return SpriteList[0];
        }
    }
}
