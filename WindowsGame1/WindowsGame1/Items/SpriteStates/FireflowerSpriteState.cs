using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class FireflowerSpriteState : SpriteStateKernel
    {
        public FireflowerSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new FireflowerSprite(),
            };
            ChangeSpriteFrequency(10);
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<FireflowerSprite>();
            }
        }
    }
}
