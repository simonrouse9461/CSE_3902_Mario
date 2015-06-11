using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class NormalBlockSprite : SpriteKernelNew
    {

        protected override void Initialize(){

            const int period = 1;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(16, 16, 16, 16)
                });
            Animation = new SpriteAnimation(null, period);

        }

        public override void Load(ContentManager content)
        {

            Source.Load(content, "blocks");
        }

    }
}
