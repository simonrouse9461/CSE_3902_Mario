using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class StarSpriteState : SpriteStateKernel
    {
        public StarSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new StarSprite(),
            };
            ChangeSpriteFrequency(10);
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<StarSprite>();
            }
        }
    }
}