using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class _1UpSprite : SpriteKernelNew
    {
        public _1UpSprite()
        {
            ImageFile.Default = "items";
            Source.Default = new SpriteSourceNew
            {
                Coodinates = new Collection<Rectangle>
                {
                    new Rectangle(260, 114, 18, 18)
                }
            };
        }
    }
}
