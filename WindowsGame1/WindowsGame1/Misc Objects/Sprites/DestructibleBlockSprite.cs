using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class DestructibleBlockSprite : SpriteKernelNew
    {

        public DestructibleBlockSprite()
        {
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(32, 16, 16, 16)
                }
            };
        }
    }
}
