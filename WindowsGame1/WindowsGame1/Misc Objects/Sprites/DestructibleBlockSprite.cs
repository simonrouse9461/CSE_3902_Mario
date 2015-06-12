using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
namespace WindowsGame1
{
    public class DestructibleBlockSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            base.Initialize();

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(32, 16, 16, 16)
                });
            Animation = new PeriodicFunction<int>();
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "blocks");
        }

    }
}
