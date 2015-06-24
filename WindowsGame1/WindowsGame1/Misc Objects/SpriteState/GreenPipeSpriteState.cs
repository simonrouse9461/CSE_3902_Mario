using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace WindowsGame1
{
    public class GreenPipeSpriteState : SpriteStateKernelNew
    {
        private enum StatusEnum
        {
            Short,
            Medium,
            Tall
        }

        private StatusEnum Status;

        public GreenPipeSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>{
                new GreenPipeSprite()
            };
            Status = StatusEnum.Tall;
        }

       
        public override ISpriteNew Sprite
        {
            get { return FindSprite<GreenPipeSprite>(); }
        }
    }
}
