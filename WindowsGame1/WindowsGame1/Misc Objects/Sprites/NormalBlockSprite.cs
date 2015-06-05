using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class NormalBlockSprite : SpriteKernel
    {

        protected override void Initialize(){

            Vector2 startCoordinate = new Vector2(15, 15);
            Vector2 endCoordinate = new Vector2(31, 31);
            const int period = 1;

            Source = new SpriteSource(startCoordinate, endCoordinate);
            Animation = new SpriteAnimation(null, period);

        }

        public override void Load(ContentManager content)
        {

            Source.Load(content, "blocks");
        }

    }
}
