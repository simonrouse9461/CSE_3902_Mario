using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class WalkingGoombaSprite : SpriteKernelNew
    {

        protected override void Initialize()
        {
            const int period = 4;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(0, 4, 15, 16),
                    new Rectangle(30, 4, 15, 16)
                });
            Animation = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 0, 0, 1, 1 };
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
