using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class IndestructibleBlockSpriteState : SpriteStateKernel
    {

        public enum StatusEnum
        {
            Indestructible
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
                new IndestructibleBlockSprite()
            };
            Status = StatusEnum.Indestructible;
        }

        public override ISprite ActiveSprite()
        {
            return SpriteList[0];
        }
    }
}
