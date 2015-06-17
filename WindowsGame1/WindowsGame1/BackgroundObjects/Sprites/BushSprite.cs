using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class BushSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int period = 1;

            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(144, 183, 34, 16)
                });
            Animation = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 0 };
                    return frameSequence[phase];
                },
                period);
        }
        public override void Load(ContentManager content)
        {
            Source.Load(content, "scenery");
        }

    }
}
