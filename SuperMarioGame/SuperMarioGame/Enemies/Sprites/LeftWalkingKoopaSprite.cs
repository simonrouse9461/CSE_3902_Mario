using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class LeftWalkingKoopaSprite : SpriteKernel
    {
        public LeftWalkingKoopaSprite()
        {
            const int period = 6;

            ImageFile.Default = "enemies";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(149, 1, 18, 23),
                    new Rectangle(179, 1, 18, 23)
                }
            };
            Animation.Default = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 1,1,0,0,1,1 };
                    return frameSequence[phase];
                },
                period);
        }
    }
}
