using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class DeadMovingUpAndDownMarioSprite : SpriteKernel
    {
        public override void Initialize()
        {
            // Source parameters
            Vector2 startCoordinate = new Vector2(0, 16);
            Vector2 endCoordinate = new Vector2(14, 29);

            // Animation parameters
            const int period = 1;

            Source = new SingleLineSpriteSource(startCoordinate, endCoordinate);
            Animation = new SpriteAnimation(null, period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "mario");
        }
    }
}