using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace WindowsGame1
{
    public class GreenPipeSpriteState : SpriteStateKernel
    {
        public GreenPipeSpriteState()
        {
            SpriteList = new Collection<ISprite>{
                new GreenPipeSprite()
            };
        }

        public override ISprite Sprite
        {
            get { return FindSprite<GreenPipeSprite>(); }
        }
    }
}
