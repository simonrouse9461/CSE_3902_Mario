using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class ExplodingFireballSprite : SpriteKernel
    {
        public ExplodingFireballSprite()
        {
            const int period = 3;
            ImageFile.Default = "misc_sprites";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(360, 946, 8, 8),
                    new Rectangle(372, 943, 12, 14),
                    new Rectangle(388, 942, 16, 16)
                }
            };
            Animation.Default = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 0, 1, 2 };
                    return frameSequence[phase];
                },
            period);
        }
    }
}
