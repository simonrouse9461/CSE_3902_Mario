using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class CoinSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            int period = 8;

            Source = new SpriteSource(
                new Collection<Rectangle>
                {
                    new Rectangle(127, 94, 12, 16),
                    new Rectangle(157, 94, 12, 16),
                    new Rectangle(187, 94, 12, 16),
                    new Rectangle(218, 94, 12, 16)
                });
            Animation = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 0, 0, 1, 1, 2, 2, 3, 3 };
                    return frameSequence[phase];
                },
                period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "items");
        }

    }
}
