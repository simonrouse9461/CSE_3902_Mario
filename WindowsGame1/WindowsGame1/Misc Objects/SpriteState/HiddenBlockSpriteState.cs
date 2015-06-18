using System.Collections.Generic;

namespace WindowsGame1
{
    public class HiddenBlockSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Hidden,
            UsedBlock
        }

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>{
                new HiddenBlockSprite(),
                new UsedBlockSprite(),
            };
            Status = StatusEnum.Hidden;
        }

        public override ISprite Sprite
        {
            get { return Status == StatusEnum.Hidden ? SpriteList[0] : SpriteList[1]; }
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
