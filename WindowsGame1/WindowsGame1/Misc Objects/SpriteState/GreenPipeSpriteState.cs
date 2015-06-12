using System;
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
                new GreenPipeSprite(),
                
            };
            Status = StatusEnum.Tall;
        }
        public override ISprite ActiveSprite()
        {
            if (Status == StatusEnum.Tall) { return SpriteList[0]; }
            else
            {
                return SpriteList[0];
            }
        }
    }
}
