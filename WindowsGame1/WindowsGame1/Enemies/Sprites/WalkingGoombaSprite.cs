using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class WalkingGoombaSprite : SpriteKernel
    {
        public WalkingGoombaSprite()
        {
            const int period = 20;

            ImageFile.Default = "enemies";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(0, 4, 16, 16),
                    new Rectangle(30, 4, 16, 16)
                }
            };
            Animation.Default = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                    return frameSequence[phase];
                },
                period);
        }
    }
}
