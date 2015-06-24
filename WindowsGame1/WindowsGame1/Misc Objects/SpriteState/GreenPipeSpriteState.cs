using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace WindowsGame1
{
    public class GreenPipeSpriteState : SpriteStateKernelNew
    {
        public GreenPipeSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>{
                new GreenPipeSprite()
            };
        }
       
        public override ISpriteNew Sprite
        {
            get { return FindSprite<GreenPipeSprite>(); }
        }
    }
}
