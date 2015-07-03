using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class CloudSprite : SpriteKernel
    {
        public CloudSprite()
        {
            ImageFile.Default = "scenery";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(8, 345, 33, 24)
                }
            };
        }
    }
}
