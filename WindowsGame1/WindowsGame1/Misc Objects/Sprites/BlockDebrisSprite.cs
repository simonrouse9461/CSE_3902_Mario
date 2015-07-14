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
            const int period = 12;
            ImageFile.Default = "block debris";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>{
                    new Rectangle(0, 0, 15, 15),
                    new Rectangle(18, 0, 22, 21),
                    new Rectangle(45, 0, 30, 22),
                    new Rectangle(84, 0, 46, 27)
                }
            };
            Animation.Default = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3 };
                    return frameSequence[phase];
                },
                period);
        }

    }
}
