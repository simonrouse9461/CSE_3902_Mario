using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class CrouchingBigMarioSprite : SpriteKernelNew
    {
        public CrouchingBigMarioSprite()
        {
            ImageFile.Default = "Mario";
            Source.Left = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(0, 57, 16, 22)
                }
            };
            Source.Right = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(389, 57, 16, 22)
                }
            };
        }
    }
}