using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
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
