using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class DestructibleBlockSprite : SpriteKernel
    {

        public DestructibleBlockSprite()
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
