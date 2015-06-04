using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class GoombaSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int totalFrames = 9;
            Vector2 startCoordinate = new Vector2(0, 0);
            Vector2 endCoordinate = new Vector2(162, 18);
            const int period = 4;

            Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
                phase =>
                {
                    int[] frameSequence = { 0, 0, 1, 1 };
                    return frameSequence[phase];
                },
                period);

        }
        public override void Load(ContentManager content)
        {
            Source.Load(content, "goomba");
        }

    }
}
