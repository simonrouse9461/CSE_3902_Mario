using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockSpriteState : SpriteStateKernel
    {
        public enum StatusEnum{
            Destructible,
            Destroyed
        }

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>{
                new DestructibleBlockSprite(),
                new DestroyedBlockSprite()
            };

            Status = StatusEnum.Destructible;
        }

        public override ISprite Sprite
        {
            get { return Status == StatusEnum.Destructible ? SpriteList[0] : SpriteList[1]; }
        }

        public void DestructibleDestroyed()
        {
            Status = StatusEnum.Destroyed;
        }

        public void DestructibleBlock()
        {
            Status = StatusEnum.Destructible;
        }
    }
}
