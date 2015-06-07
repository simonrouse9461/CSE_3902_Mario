using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class SitLeftBMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            // Source parameters
            Vector2 startCoordinate = new Vector2(0,50);
            Vector2 endCoordinate = new Vector2(20, 85);

            // Animation parameters
            const int period = 1;

            Source = new SpriteSource(startCoordinate, endCoordinate);
            Animation = new SpriteAnimation(null, period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}