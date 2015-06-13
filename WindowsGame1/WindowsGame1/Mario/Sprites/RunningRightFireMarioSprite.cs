using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{

    public class RunningRightFireMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            const int period = 3;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(237, 122, 16, 32),
                    new Rectangle(263, 122, 14, 31),
                    new Rectangle(287, 123, 16, 30),
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
