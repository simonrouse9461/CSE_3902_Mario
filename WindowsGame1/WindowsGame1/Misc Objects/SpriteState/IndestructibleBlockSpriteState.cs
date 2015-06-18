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

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>{
                new IndestructibleBlockSprite()
            };

            Status = StatusEnum.Indestructible;
        }

        public override ISprite Sprite
        {
            get { return SpriteList[0]; }
        }
    }
}
