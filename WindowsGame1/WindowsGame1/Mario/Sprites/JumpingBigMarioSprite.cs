using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class JumpingBigMarioSprite : SpriteKernelNew
    {
        public JumpingBigMarioSprite()
        {
            ImageFile.Default = "Mario";
            Source.Left = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(30, 52, 16, 32)
                }
            };
            Source.Right = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(359, 52, 16, 32)
                }
            };
        }
    }
}