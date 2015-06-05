using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class UsedBlockSprite : SpriteKernel
    {
        protected override void Initialize(){

        
        Vector2 startCoordinate = new Vector2(0, 32);
        Vector2 endCoordinate = new Vector2(16, 48);
        Source = new SpriteSource(startCoordinate, endCoordinate);
        Animation = new SpriteAnimation(null, 0);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "blocks");
        }

    }
}
