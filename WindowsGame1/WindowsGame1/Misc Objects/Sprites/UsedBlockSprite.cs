using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class UsedBlockSprite : SpriteKernel
    {
        public UsedBlockSprite()
        {
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSource{
                Coordinates = new Collection<Rectangle>{
                    new Rectangle(0,32,16,16),
                }
            };
        }
    }
}
