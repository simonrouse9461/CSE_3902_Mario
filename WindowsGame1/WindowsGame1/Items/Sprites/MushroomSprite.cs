using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class MushroomSprite : SpriteKernelNew
    {

        protected override void Initialize()
        {
            //const int totalFrames = 1;
            //Vector2 startCoordinate = new Vector2(181, 31);
            //Vector2 endCoordinate = new Vector2(204, 54);
            const int period = 1;

            //Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Source = new SpriteSourceNew(
            new List<Rectangle>
            {
                new Rectangle(183, 33, 18, 18)
            });
            Animation = new PeriodicFunction(
                phase =>
                {
                    int[] frameSequence = { 0 };
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
