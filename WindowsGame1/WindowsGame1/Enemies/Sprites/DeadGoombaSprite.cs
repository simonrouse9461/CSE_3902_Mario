using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class DeadGoombaSprite : SpriteKernelNew
    {

        protected override void Initialize()
        {
            const int period = 1;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(60, 7, 16, 10)
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
            Source.Load(content, "enemies");
        }

    }
}
