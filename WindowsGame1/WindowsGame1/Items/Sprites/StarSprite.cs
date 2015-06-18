using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class StarSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int period = 8;

            Source = new SpriteSource(
                new Collection<Rectangle>
                {
                    new Rectangle(5, 94, 14, 16),
                    new Rectangle(35, 94, 14, 16),
                    new Rectangle(65, 94, 14, 16),
                    new Rectangle(95, 94, 14, 16)
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
