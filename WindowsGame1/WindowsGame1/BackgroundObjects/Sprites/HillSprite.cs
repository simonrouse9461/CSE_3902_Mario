using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class HillSprite : SpriteKernelNew
    {
        public HillSprite()
        {
            ImageFile.Default = "misc";
            Source.Default = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(86, 5, 80, 35)
                }
            };
        }
    }
}
