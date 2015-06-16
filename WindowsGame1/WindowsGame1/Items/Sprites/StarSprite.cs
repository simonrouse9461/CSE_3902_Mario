using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class StarSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int period = 4;

            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(5, 94, 14, 16),
                    new Rectangle(34, 94, 14, 16),
                    new Rectangle(65, 94, 14, 16),
                    new Rectangle(95, 94, 14, 16)
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
