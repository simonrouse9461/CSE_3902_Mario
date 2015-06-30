using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class JumpingFireMarioSprite : SpriteKernel
    {
        public JumpingFireMarioSprite()
        {
            ImageFile.Default = "Mario";
            Source.Left = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(27, 122, 16, 32)
                }
            };
            Source.Right = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(363, 122, 16, 32)
                }
            };
        }
    }
}