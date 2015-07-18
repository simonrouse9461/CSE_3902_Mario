using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class BushSpriteState :SpriteStateKernel
    {
        public BushSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new BushSprite()
            };
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<BushSprite>();
            }
        }
    }
}
