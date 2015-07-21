using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame
{
    public class SwimmingBigMarioSprite: SpriteKernel
    {
        public SwimmingBigMarioSprite()
        {
            const int period = 8;

            ImageFile.Default = "Mario";
            Source.Left = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(1, 88, 14, 30),
                    new Rectangle(28, 89, 14, 27),
                    new Rectangle(52, 88, 16, 30),
                    new Rectangle(78, 88, 14, 30),
                    new Rectangle(103, 88, 14, 30),
                    new Rectangle(127, 88, 16, 29),
                    new Rectangle(152, 88, 16, 29),
                    new Rectangle(180, 88, 16, 29)
                }
            };
            Animation.Left = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {7, 6, 5, 4, 3, 2, 1, 0};
                    return frameSequence[phase];
                }, 
                period);
            Source.Right = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(209, 88, 16, 29),
                    new Rectangle(237, 88, 16, 29),
                    new Rectangle(262, 88, 16, 29),
                    new Rectangle(288, 88, 14, 30),
                    new Rectangle(313, 88, 14, 30),
                    new Rectangle(337, 88, 16, 30),
                    new Rectangle(363, 89, 14, 27),
                    new Rectangle(390, 88, 14, 30)
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