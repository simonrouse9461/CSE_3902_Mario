using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class BlockDebrisSprite : SpriteKernel
    {
        public BlockDebrisSprite()
        {
            const int period = 4;
            ImageFile.Default = "block debris";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>{
                    new Rectangle(0, 0, 15, 15),
                    new Rectangle(18, 0, 22, 15),
                    new Rectangle(43, 0, 28, 18),
                    new Rectangle(3, 20, 34, 24)
                }
            };
            Animation.Default = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 0, 1, 2, 3 };
                    return frameSequence[phase];
                },
                period);
        }

    }
}
