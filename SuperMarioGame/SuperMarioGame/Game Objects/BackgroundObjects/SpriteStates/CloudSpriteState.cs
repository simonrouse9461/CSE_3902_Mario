using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CloudSpriteState : SpriteStateKernel<int>
    {
        public CloudSpriteState()
        {
            AddSprite<CloudHeadSprite>();
            AddSprite<CloudBodySprite>();
            AddSprite<CloudTailSprite>();
        }

        public void Head()
        {
            SetSprite<CloudHeadSprite>();
        }

        public void Body()
        {
            SetSprite<CloudBodySprite>();
        }

        public void Tail()
        {
            SetSprite<CloudTailSprite>();
        }
    }
}
