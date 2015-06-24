using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class MushroomSprite : SpriteKernelNew
    {
        public MushroomSprite()
        {
            ImageFile.Default = "items";
            Source.Default = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(183, 33, 18, 18)
                }
            };
        }
    }
}
