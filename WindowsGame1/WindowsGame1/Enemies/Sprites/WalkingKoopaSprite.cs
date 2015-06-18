using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class WalkingKoopaSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int period = 8;

            Source = new SpriteSource(
                new Collection<Rectangle>
                {
                    new Rectangle(149, 1, 18, 23),
                    new Rectangle(179, 1, 18, 23),
                    new Rectangle(209, 1, 18, 23),
                    new Rectangle(239,1, 18,23)
                });
            Animation = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 2, 2, 1, 1, 0, 0, 3, 3 };
                    return frameSequence[phase];
                },
                period);
        }
        public override void Load(ContentManager content)
        {

            Source.Load(content, "enemies");
        }

    }
}
