using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace MarioGame
{
    public class GreenPipeSpriteState : SpriteStateKernel
    {

        private enum StatusEnum
        {
            Tall,
            Medium,
            Small,
            Secret
        }

        private StatusEnum status;
        public GreenPipeSpriteState()
        {
            SpriteList = new Collection<ISprite>{
                new LargeGreenPipeSprite(),
                new SmallGreenPipeSprite(),
                new MediumGreenPipeSprite(),
                new SecretGreenPipeSprite()
            };
        }

        protected override ISprite RawSprite
        {
            get {

                switch (status)
                {
                    case StatusEnum.Tall:
                        return FindSprite<LargeGreenPipeSprite>();
                        
                    case StatusEnum.Small:
                        return FindSprite<SmallGreenPipeSprite>();
                        
                    case StatusEnum.Medium:
                        return FindSprite<MediumGreenPipeSprite>();
                        
                    case StatusEnum.Secret:
                        return FindSprite<SecretGreenPipeSprite>();
                        
                    default:
                        return FindSprite<LargeGreenPipeSprite>();
                }
            }
        }

        public void TallPipe(){
            status = StatusEnum.Tall;
        }

        public void SmallPipe()
        {
            status = StatusEnum.Small;
        }

        public void MediumPipe()
        {
            status = StatusEnum.Medium;
        }

        public void SecretPipe()
        {
            status = StatusEnum.Secret;
        }
    }
}
