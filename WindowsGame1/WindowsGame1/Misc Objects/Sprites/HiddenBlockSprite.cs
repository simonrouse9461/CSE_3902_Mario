using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class HiddenBlockSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            
            Vector2 startCoordinate = new Vector2(16, 32);
            Vector2 endCoordinate = new Vector2(31, 47);
            

            Source = new SpriteSource(startCoordinate, endCoordinate);
            Animation = new SpriteAnimation(null, 0);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "blocks");
        }
    }
}
