using System.Collections.Generic;

namespace WindowsGame1
{
    public class GreenPipeSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Short,
            Medium,
            Tall
        }

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>{
                new GreenPipeSprite()
            };
            Status = StatusEnum.Tall;
        }

        public override ISprite Sprite
        {
            get { return SpriteList[0]; }
        }
    }
}
