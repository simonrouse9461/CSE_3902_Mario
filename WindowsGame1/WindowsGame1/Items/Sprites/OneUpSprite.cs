using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame
{
    public class OneUpSprite : SpriteKernel
    {
        public OneUpSprite()
        {
            ImageFile.Default = "items";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(214, 34, 16, 16)
                }
            };
        }
    }
}
