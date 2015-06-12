using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class FireflowerSprite : SpriteKernelNew
    {

        protected override void Initialize()
        {
            //const int totalFrames = 4;
            //Vector2 startCoordinate = new Vector2(0, 64);
            //Vector2 endCoordinate = new Vector2(120, 81);
            const int period = 4;

            //Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(3, 64, 17, 18),
                    new Rectangle(33, 64, 17, 18),
                    new Rectangle(63, 64, 17, 18),
                    new Rectangle(93, 64, 17, 18)
                });
            Animation = new PeriodicFunction(
                phase =>
                {
                    int[] frameSequence = { 0, 1, 2, 3 };
                    return frameSequence[phase];
                },
                period);

        }
        public override void Load(ContentManager content)
        {

            Source.Load(content, "items");
        }

    }
}
