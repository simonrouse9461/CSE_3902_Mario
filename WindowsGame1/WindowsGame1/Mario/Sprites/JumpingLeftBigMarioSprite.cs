using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class JumpingLeftBigMarioSprite: SpriteKernelNew
    {
        protected override void Initialize()
        {
            const int period = 8;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(1, 88, 14, 30),
                    new Rectangle(28, 89, 14, 27),
                    new Rectangle(52, 88, 16, 30),
                    new Rectangle(78, 88, 14, 30),
                    new Rectangle(103, 88, 14, 30),
                    new Rectangle(127, 88, 16, 29),
                    new Rectangle(152, 88, 16, 29),
                    new Rectangle(180, 88, 16, 29)
                });
            Animation = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {7, 6, 5, 4, 3, 2, 1, 0};
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