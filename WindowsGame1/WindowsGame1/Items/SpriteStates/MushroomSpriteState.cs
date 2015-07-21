using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class MushroomSpriteState : SpriteStateKernel
    {
        public MushroomSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new MushroomSprite(),
            };
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<MushroomSprite>();
            }
        }
    }

}
