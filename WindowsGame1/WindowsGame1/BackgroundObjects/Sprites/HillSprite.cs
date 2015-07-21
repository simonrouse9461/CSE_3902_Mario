using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class HillSprite : SpriteKernel
    {
        public HillSprite()
        {
            ImageFile.Default = "misc";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(86, 5, 80, 35)
                }
            };
        }
    }
}
