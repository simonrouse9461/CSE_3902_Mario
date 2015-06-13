using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class JumpingRightSmallMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            const int period = 6;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(210, 30, 15, 15),
                    new Rectangle(240, 30, 14, 15),
                    new Rectangle(270, 30, 14, 15),
                    new Rectangle(301, 30, 14, 15),
                    new Rectangle(331, 30, 13 ,15),
                    new Rectangle(361, 30, 14, 16),
                });
            Animation = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {0, 1, 2, 3, 4, 5};
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