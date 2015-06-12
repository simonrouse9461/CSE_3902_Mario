using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockSpriteState : SpriteStateKernel
    {

        public enum StatusEnum{
            Destructible
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
                new DestructibleBlockSprite()
            };
            Status = StatusEnum.Destructible;
        }

        public override ISprite ActiveSprite()
        {
            return SpriteList[0];
        }
    }
}
