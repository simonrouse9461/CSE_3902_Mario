using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class HiddenBlockSprite : SpriteKernel
    {
        public HiddenBlockSprite()
        {
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSource{
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(16, 32, 16, 16)
                }
            };
        }
    }
}
