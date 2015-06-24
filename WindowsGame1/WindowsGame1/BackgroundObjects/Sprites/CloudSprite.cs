using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class CloudSprite : SpriteKernelNew
    {
        public CloudSprite()
        {
            ImageFile.Default = "scenery";
            Source.Default = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(8, 344, 33, 24)
                }
            };
        }
    }
}
