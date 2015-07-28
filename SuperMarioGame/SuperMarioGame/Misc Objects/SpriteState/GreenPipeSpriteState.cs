using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace SuperMario
{
    public class GreenPipeSpriteState : SpriteStateKernelNew<int>
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
            AddSprite<LargeGreenPipeSprite>();
            AddSprite<SmallGreenPipeSprite>();
            AddSprite<MediumGreenPipeSprite>();
            AddSprite<SecretGreenPipeSprite>();
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
