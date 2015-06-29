using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
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

        public override ISprite Sprite
        {
            get
            {
                return FindSprite<CloudSprite>();
            }
        }
    }
}
