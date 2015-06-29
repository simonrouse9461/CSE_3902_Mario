using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class DeGrowingBigMarioSprite : SpriteKernel
    {
        public DeGrowingBigMarioSprite()
        {
            const int period = 6;
            ImageFile.Default = "Mario";
            Source.Left = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(180, 0, 14, 16),
                    new Rectangle(180, 51, 16, 31)
                }
            };
            Animation.Left = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {1,0,1,0,1,0};
                    return frameSequence[phase];
                }, 
                period);
            Source.Right = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(210, 0, 13, 15),
                    new Rectangle(209, 52, 15, 31)
                }
            };
            Animation.Right = new PeriodicFunction<int>(
               phase =>
               {
                   int[] frameSequence = { 1, 0, 1, 0, 1, 0 };
                   return frameSequence[phase];
               },
               period);
        }
    }
}