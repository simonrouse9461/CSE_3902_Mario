using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class KoopaSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int totalFrames = 4;
            
            Vector2 startCoordinate = new Vector2(145, 0);
            Vector2 endCoordinate = new Vector2(260, 25);
            const int period = 8;

            Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
                phase =>
                {
                    int[] frameSequence = { 2, 2, 1, 1, 0, 0, 3, 3 };
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
