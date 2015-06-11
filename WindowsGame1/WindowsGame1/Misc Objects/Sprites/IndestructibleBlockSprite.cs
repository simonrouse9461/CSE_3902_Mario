using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
namespace WindowsGame1
{
    public class IndestructibleBlockSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {

            Vector2 startCoordinate = new Vector2(0, 17);
            Vector2 endCoordinate = new Vector2(15, 32);
            const int period = 1;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(0 ,17, 16, 16)
                });
            Animation = new SpriteAnimation(null, period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "blocks");
        }

    }
}
