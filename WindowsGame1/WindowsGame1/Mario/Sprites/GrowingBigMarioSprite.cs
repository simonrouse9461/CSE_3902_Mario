using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class GrowingBigMarioSprite : SpriteKernel
    {
        public GrowingBigMarioSprite()
        {
            const int period = 10;
            ImageFile.Default = "characters";
            Source.Left = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(224, 44, 12, 16),
                    new Rectangle(239, 36, 16, 24),
                    new Rectangle(239, 1, 16, 32)
                }
            };
            Animation.Left = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {0, 1, 0, 1, 0, 1, 2, 0, 1, 2};
                    return frameSequence[phase];
                }, 
                period);
            Source.Right = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(277, 44, 12, 16),
                    new Rectangle(258, 36, 16, 24),
                    new Rectangle(258, 1, 16, 32)
                }
            };
            Animation.Right = new PeriodicFunction<int>(
               phase =>
               {
                   int[] frameSequence = {0, 1, 0, 1, 0, 1, 2, 0, 1, 2};
                   return frameSequence[phase];
               },
               period);
        }
    }
}