using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class RunningSmallMarioSprite : SpriteKernel
    {
        public RunningSmallMarioSprite()
        {
            const int period = 3;

            ImageFile.Default = "Mario";
            Source.Left = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(89, 0, 16, 16),
                    new Rectangle(121, 0, 12, 16),
                    new Rectangle(150, 0, 14, 15)
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
                    new Rectangle(241, 0, 14, 15),
                    new Rectangle(272, 0, 12, 16),
                    new Rectangle(300, 0, 16, 16)
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