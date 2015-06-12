using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class RunningLeftSmallMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            // Animation parameters
            const int period = 3;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(85, 0, 16, 16),
                    new Rectangle(121, 0, 12, 16),
                    new Rectangle(150, 0, 14, 15)
                });
            Animation = new PeriodicFunction(
                phase =>
                {
                    int[] frameSequence = {0,1,2};
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