using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class CoinSprite : SpriteKernelNew
    {

        protected override void Initialize()
        {
            Vector2 startCoordinate = new Vector2(119, 91);
            Vector2 endCoordinate = new Vector2(242, 114);
            int period = 4;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(127, 94, 12, 16),
                    new Rectangle(158, 94, 12, 16),
                    new Rectangle(179, 91, 12, 16),
                    new Rectangle(219, 91, 12, 16)
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
