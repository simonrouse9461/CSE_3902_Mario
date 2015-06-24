using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class CloudSpriteState : SpriteStateKernelNew
    {
        public CloudSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new CloudSprite()
            };
        }

        public override ISpriteNew Sprite
        {
            get
            {
                return FindSprite<CloudSprite>();
            }
        }
    }
}
