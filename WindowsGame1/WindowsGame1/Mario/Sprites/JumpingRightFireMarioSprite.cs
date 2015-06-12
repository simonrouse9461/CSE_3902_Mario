using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class JumpingRightFireMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            // Animation parameters
            const int period = 8;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(209, 158, 16, 29),
                    new Rectangle(237, 158, 16, 29),
                    new Rectangle(262, 158, 16, 29),
                    new Rectangle(288, 158, 14, 30),
                    new Rectangle(313, 158, 14, 30),
                    new Rectangle(337, 158, 16, 30),
                    new Rectangle(363, 159, 14, 27),
                    new Rectangle(390, 158, 14, 30)
                });
            Animation = new PeriodicFunction(
                phase =>
                {
                    int[] frameSequence = {0,1,2,3,4,5,6,7};
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