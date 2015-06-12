using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class GreenPipeSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            Vector2 startCoordinate = new Vector2(0, 0);
            Vector2 endCoordinate = new Vector2(30, 61);

            Source = new SpriteSource(startCoordinate, endCoordinate);
            Animation = new PeriodicFunction<int>();
        }
        public override void Load(ContentManager content)
        {

            Source.Load(content, "single green pipe");
        }

    }
}
