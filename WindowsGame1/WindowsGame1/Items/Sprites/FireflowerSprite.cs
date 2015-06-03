using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class FireflowerSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            Vector2 startCoordinate = new Vector2(0, 16);
            Vector2 endCoordinate = new Vector2(14, 29);
            const int period = 1;

            Source = new SpriteSource(startCoordinate, endCoordinate);
            Animation = new SpriteAnimation(null, period);

        }
        public override void Load(ContentManager content)
        {

            Source.Load(content, "Fireflower");
        }

    }
}
