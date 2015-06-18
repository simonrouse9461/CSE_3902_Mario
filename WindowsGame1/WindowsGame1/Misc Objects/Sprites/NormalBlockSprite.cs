using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class NormalBlockSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            Source = new SpriteSource(
                new Collection<Rectangle>
                {
                    new Rectangle(16, 16, 16, 16)
                });
        }

        public override void Load(ContentManager content)
        {

            Source.Load(content, "blocks");
        }

    }
}
