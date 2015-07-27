using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class HarpSpriteState : SpriteStateKernel
    {
        public HarpSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new HarpSprite()
            };
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<HarpSprite>();
            }
        }
    }
}