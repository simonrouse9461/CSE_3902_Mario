using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class UsedBlockSprite : SpriteKernelNew
    {

        public UsedBlockSprite()
        {
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSourceNew{
                Coordinates = new Collection<Rectangle>{
                    new Rectangle(0,32,16,16),
                }
            };
        }
    }
}
