using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class FireflowerSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int period = 4;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(3, 64, 17, 18),
                    new Rectangle(33, 64, 17, 18),
                    new Rectangle(63, 64, 17, 18),
                    new Rectangle(93, 64, 17, 18)
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
