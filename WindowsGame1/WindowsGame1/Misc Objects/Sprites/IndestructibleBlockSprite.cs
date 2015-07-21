using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class IndestructibleBlockSprite : SpriteKernel
    {

        public IndestructibleBlockSprite()
        {
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSource{
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(0 ,17, 16, 16)
                }
            };
        }
    }
}
