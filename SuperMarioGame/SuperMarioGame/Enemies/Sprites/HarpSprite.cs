using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class HarpSprite : SpriteKernel
    {
        public HarpSprite()
        {
            ImageFile.Default = "harp";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(4, 1, 51, 73)
                }
            };
        }
    }
}
