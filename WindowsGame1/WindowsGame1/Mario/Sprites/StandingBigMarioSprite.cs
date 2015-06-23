using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class StandingBigMarioSprite : SpriteKernelNew
    {
        public StandingBigMarioSprite()
        {
            ImageFile.Default = "Mario";
            Source.Left = new SpriteSourceNew
            {
                Coodinates = new Collection<Rectangle>
                {
                    new Rectangle(180, 52, 16, 32)
                }
            };
            Source.Right = new SpriteSourceNew
            {
                Coodinates = new Collection<Rectangle>
                {
                    new Rectangle(209, 52, 16, 32)
                }
            };
        }
    }
}