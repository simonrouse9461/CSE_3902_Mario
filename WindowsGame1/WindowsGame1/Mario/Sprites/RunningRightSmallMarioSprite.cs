using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{

    public class RunningRightSmallMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            const int period = 3;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(241, 0, 14, 15),
                    new Rectangle(272, 0, 12, 16),
                    new Rectangle(300, 0, 16, 16)
                });
            Animation = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {2, 1, 0};
                    return frameSequence[phase];
                },
                period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}
