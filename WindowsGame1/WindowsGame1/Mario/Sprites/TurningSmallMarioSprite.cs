using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class TurningSmallMarioSprite : SpriteKernelNew
    {
        public TurningSmallMarioSprite()
        {
            ImageFile.Default = "Mario";
            Source.Left = new SpriteSourceNew
            {
                Coodinates = new Collection<Rectangle>
                {
                    new Rectangle(60, 0, 14, 16)
                }
            };
            Source.Right = new SpriteSourceNew
            {
                Coodinates = new Collection<Rectangle>
                {
                    new Rectangle(331, 0, 14, 16)
                }
            };
        }
    }
}