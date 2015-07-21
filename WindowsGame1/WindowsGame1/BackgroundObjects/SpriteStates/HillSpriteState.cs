using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class HillSpriteState : SpriteStateKernel
    {
        public HillSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new HillSprite()
            };
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<HillSprite>();
            }
        }
    }
}
