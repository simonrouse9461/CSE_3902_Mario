using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class DestroyedBlockSprite : SpriteKernelNew
    {


        protected override void Initialize()
        {
            const int period = 1;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(16, 32, 16, 16)
                });
            Animation = new PeriodicFunction(null, period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "blocks");
        }
    }
}
