using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class NormalBlockSprite : SpriteKernel
    {
        public NormalBlockSprite()
        {
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSource{
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(16, 16, 16, 16)
                }
            };
        }
    }
}
