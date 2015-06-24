using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class GreenPipeSprite : SpriteKernelNew
    {
        public GreenPipeSprite()
        {
            ImageFile.Default = "misc";
            Source.Default = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(230, 385, 32, 64)
                }
            };
        }
    }
}
