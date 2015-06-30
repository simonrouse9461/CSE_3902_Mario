using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class FireballSprite : SpriteKernel
    {
        public FireballSprite()
        {
            ImageFile.Default = "misc_sprites";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(313, 945, 8, 8),
                    new Rectangle(324, 945, 8, 8),
                    new Rectangle(336, 945, 8, 8),
                    new Rectangle(348, 945, 8, 8)
                }
            };
        }
    }
}
