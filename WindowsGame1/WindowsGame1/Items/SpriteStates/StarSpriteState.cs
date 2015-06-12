using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class StarSpriteState : SpriteStateKernel
    {
        protected override void Initialize()
        {
            base.Initialize();

            SpriteList = new List<ISprite>
            {
                new StarSprite(), //0
            };
        }

        public override ISprite ActiveSprite()
        {
            return SpriteList[0];
        }
    }
}