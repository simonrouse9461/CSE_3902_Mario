using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class FloorBlockSprite : SpriteKernel
    {

        public FloorBlockSprite()
        {
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(32, 16, 16, 16)
                }
            };
        }
    }
}
