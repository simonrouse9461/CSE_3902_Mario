using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class RunningLeftBigMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            // Animation parameters
            const int period = 3;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(90, 53, 16, 30),
                    new Rectangle(121, 52, 14, 31),
                    new Rectangle(150, 52, 16, 32)
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