using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class HillSpriteState : SpriteStateKernel
    {
        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new HillSprite()
            };
        }

        public override ISprite Sprite
        {
            get { return SpriteList[0]; }
        }
    }
}
