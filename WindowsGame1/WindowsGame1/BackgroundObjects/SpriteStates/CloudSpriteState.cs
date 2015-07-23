using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CloudSpriteState : SpriteStateKernel
    {
        public CloudSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new CloudSprite()
            };
        }

        protected override ISprite RawSprite
        {
            get
            {
                return FindSprite<CloudSprite>();
            }
        }
    }
}
