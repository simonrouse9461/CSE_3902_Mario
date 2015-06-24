using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class WalkingKoopaSprite : SpriteKernelNew
    {
        public WalkingKoopaSprite()
        {
            const int period = 12;

            ImageFile.Default = "enemies";
            Source.Default = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(149, 1, 18, 23),
                    new Rectangle(179, 1, 18, 23),
                    new Rectangle(209, 1, 18, 23),
                    new Rectangle(239,1, 18,23)
                }
            };
            Animation.Default = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 1,1,0,0,1,1,2,2,3,3,2,2 };
                    return frameSequence[phase];
                },
                period);
        }
    }
}
