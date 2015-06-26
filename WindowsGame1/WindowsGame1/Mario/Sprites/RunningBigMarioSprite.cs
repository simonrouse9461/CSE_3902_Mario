using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class RunningBigMarioSprite : SpriteKernel
    {
        public RunningBigMarioSprite()
        {
            const int period = 3;

            ImageFile.Default = "Mario";
            Source.Left = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(90, 53, 16, 30),
                    new Rectangle(121, 52, 14, 31),
                    new Rectangle(150, 52, 16, 32)
                }
            };
            Animation.Left = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {0, 1, 2};
                    return frameSequence[phase];
                }, 
                period);
            Source.Right = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(239, 52, 16, 32),
                    new Rectangle(270, 52, 14, 31),
                    new Rectangle(299, 53, 16, 30)
                }
            };
            Animation.Right = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {2, 1, 0};
                    return frameSequence[phase];
                },
                period);
        }
    }
}