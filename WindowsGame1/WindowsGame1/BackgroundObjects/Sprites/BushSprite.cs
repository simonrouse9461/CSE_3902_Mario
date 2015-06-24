using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class BushSprite : SpriteKernelNew
    {
        public BushSprite()
        {
            ImageFile.Default = "scenery";
            Source.Default = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(183, 144, 34, 16)
                }
            };
        }
    }
}
