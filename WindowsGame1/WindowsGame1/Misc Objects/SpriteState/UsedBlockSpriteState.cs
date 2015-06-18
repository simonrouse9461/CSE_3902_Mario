using System.Collections.Generic;

namespace WindowsGame1
{
    public class UsedBlockSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Used
        }

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>{
                new UsedBlockSprite()
            };

            Status = StatusEnum.Used;
        }

        public override ISprite Sprite
        {
            get { return SpriteList[0]; }
        }
    }
}
