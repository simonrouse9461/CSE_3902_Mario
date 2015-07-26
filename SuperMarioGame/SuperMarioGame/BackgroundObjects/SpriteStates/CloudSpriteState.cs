using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CloudSpriteState : SpriteStateKernelNew<int>
    {
        public CloudSpriteState()
        {
            AddSprite<CloudSprite>();
            SetSprite<CloudSprite>();
        }
    }
}
