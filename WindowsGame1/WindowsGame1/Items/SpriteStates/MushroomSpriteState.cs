using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MushroomSpriteState : SpriteStateKernel
    {

        protected override void Initialize()
        {
            base.Initialize();

            SpriteList = new List<ISprite>
            {
                new MushroomSprite(),
            };
        }

        public override ISprite ActiveSprite()
        {
            return SpriteList[0];    
        }
    }

}
