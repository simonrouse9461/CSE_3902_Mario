using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class StarSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int totalFrames = 4;
            Vector2 startCoordinate = new Vector2(0, 91);
            Vector2 endCoordinate = new Vector2(121, 114);
            const int period = 4;

            Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
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
