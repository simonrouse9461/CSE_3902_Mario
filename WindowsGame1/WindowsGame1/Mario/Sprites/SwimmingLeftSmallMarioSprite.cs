using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class SwimmingLeftSmallMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            const int period = 6;

            Source = new SpriteSource(
                new Collection<Rectangle>
                {
                    new Rectangle(30, 30, 14, 16),
                    new Rectangle(61, 30, 13 ,15),
                    new Rectangle(90, 30, 14, 15),
                    new Rectangle(120, 30, 14, 15),
                    new Rectangle(150, 30, 14, 15),
                    new Rectangle(180, 30, 15, 15)
                });
            Animation = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {5, 4, 3, 2, 1, 0};
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