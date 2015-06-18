using System.Collections.Generic;

namespace WindowsGame1
{
    public class CloudSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Still
        }

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new CloudSprite()
            };

            Status = StatusEnum.Still;
        }

        public override ISprite Sprite
        {
            get { return SpriteList[0]; }
        }
    }
}
