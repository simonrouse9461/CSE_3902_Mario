using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class OneUpSpriteState : SpriteStateKernel
    {
        public OneUpSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new OneUpSprite()
            };
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<OneUpSprite>();
            }
        }
    }
}
