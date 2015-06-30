using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
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

        public override ISprite Sprite
        {
            get
            {
                return FindSprite<StarSprite>();
            }
        }
    }
}