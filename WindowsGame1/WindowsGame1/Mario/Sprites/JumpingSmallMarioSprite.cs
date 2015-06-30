using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class JumpingSmallMarioSprite : SpriteKernel
    {
        public JumpingSmallMarioSprite()
        {
            ImageFile.Default = "Mario";
            Source.Left = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(29, 0, 17, 16)
                }
            };
            Source.Right = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(359, 0, 17, 16)
                }
            };
        }
    }
}