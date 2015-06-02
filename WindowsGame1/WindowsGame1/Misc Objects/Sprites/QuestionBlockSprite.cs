using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class QuestionBlockSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int totalFrames = 3;
            Vector2 startCoordinate = new Vector2(0, 0);
            Vector2 endCoordinate = new Vector2(48, 48);
            const int period = 3;

            Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
            phase => 
            {
                int[] frameSequence = {0, 1, 2};
                return frameSequence[phase];
            },
            period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "question block");
        }
    }
}
