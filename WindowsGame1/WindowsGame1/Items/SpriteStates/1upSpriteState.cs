using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class _1upSpriteState : SpriteStateKernel
    {

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new _1upSprite()
            };
        }

        public override ISprite ActiveSprite()
        {
            return SpriteList[0];
        }
    }
}
