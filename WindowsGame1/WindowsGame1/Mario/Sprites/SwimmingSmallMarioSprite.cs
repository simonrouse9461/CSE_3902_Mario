using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class SwimmingSmallMarioSprite : SpriteKernel
    {
        public SwimmingSmallMarioSprite()
        {
            const int period = 6;

            ImageFile.Default = "Mario";
            Source.Left = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(30, 30, 14, 16),
                    new Rectangle(61, 30, 13 ,15),
                    new Rectangle(90, 30, 14, 15),
                    new Rectangle(120, 30, 14, 15),
                    new Rectangle(150, 30, 14, 15),
                    new Rectangle(180, 30, 15, 15)
                }
            };
            Animation.Left = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {5, 4, 3, 2, 1, 0};
                    return frameSequence[phase];
                }, 
                period);
            Source.Right = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(210, 30, 15, 15),
                    new Rectangle(240, 30, 14, 15),
                    new Rectangle(270, 30, 14, 15),
                    new Rectangle(301, 30, 14, 15),
                    new Rectangle(331, 30, 13 ,15),
                    new Rectangle(361, 30, 14, 16)
                }
            };
            Animation.Right = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {0, 1, 2, 3, 4, 5};
                    return frameSequence[phase];
                },
                period);
        }
    }
}