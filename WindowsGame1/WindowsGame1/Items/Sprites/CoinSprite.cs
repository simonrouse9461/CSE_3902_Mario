using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class CoinSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            Vector2 startCoordinate = new Vector2(119, 91);
            Vector2 endCoordinate = new Vector2(242, 114);
            int period = 4;

            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(127, 94, 12, 16),
                    new Rectangle(155, 94, 12, 16),
                    new Rectangle(187, 94, 12, 16),
                    new Rectangle(218, 94, 12, 16)
                });
            Animation = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 0, 1, 2, 3 };
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
