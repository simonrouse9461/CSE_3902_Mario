using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class UsedBlockSpriteState : SpriteStateKernel
    {

        public enum StatusEnum
        {
            Used
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
                new UsedBlockSprite()
            };
            Status = StatusEnum.Used;
        }

        public override ISprite ActiveSprite()
        {
            return SpriteList[0];
        }
    }
}
