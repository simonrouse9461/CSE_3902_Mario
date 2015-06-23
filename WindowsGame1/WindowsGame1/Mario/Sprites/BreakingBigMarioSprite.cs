using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class BreakingBigMarioSprite : SpriteKernelNew
    {
        public BreakingBigMarioSprite()
        {
            ImageFile.Default = "Mario";
            Source.Left = new SpriteSourceNew
            {
                Coodinates = new Collection<Rectangle>
                {
                    new Rectangle(329, 52, 16, 32)
                }
            };
            Source.Right = new SpriteSourceNew
            {
                Coodinates = new Collection<Rectangle>
                {
                    new Rectangle(60, 52, 16, 32)
                }
            };
        }
    }
}