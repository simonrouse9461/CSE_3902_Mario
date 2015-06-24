using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class IndestructibleBlockSprite : SpriteKernelNew
    {

        public IndestructibleBlockSprite()
        {
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSourceNew{
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(0 ,17, 16, 16)
                }
            };
        }
    }
}
