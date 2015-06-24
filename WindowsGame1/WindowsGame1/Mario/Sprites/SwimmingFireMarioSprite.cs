using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class SwimmingFireMarioSprite : SpriteKernelNew
    {
        public SwimmingFireMarioSprite()
        {
            const int period = 8;

            ImageFile.Default = "Mario";
            Source.Left = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(1, 158, 14, 30),
                    new Rectangle(28, 159, 14, 27),
                    new Rectangle(52, 158, 16, 30),
                    new Rectangle(78, 158, 14, 30),
                    new Rectangle(103, 158, 14, 30),
                    new Rectangle(127, 158, 16, 29),
                    new Rectangle(152, 158, 16, 29),
                    new Rectangle(180, 158, 16, 29)
                }
            };
            Animation.Left = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {7, 6, 5, 4, 3, 2, 1, 0};
                    return frameSequence[phase];
                }, 
                period);
            Source.Right = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(209, 158, 16, 29),
                    new Rectangle(237, 158, 16, 29),
                    new Rectangle(262, 158, 16, 29),
                    new Rectangle(288, 158, 14, 30),
                    new Rectangle(313, 158, 14, 30),
                    new Rectangle(337, 158, 16, 30),
                    new Rectangle(363, 159, 14, 27),
                    new Rectangle(390, 158, 14, 30)
                }
            };
            Animation.Right = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {0, 1, 2, 3, 4, 5, 6, 7};
                    return frameSequence[phase];
                },
                period);
        }
    }
}