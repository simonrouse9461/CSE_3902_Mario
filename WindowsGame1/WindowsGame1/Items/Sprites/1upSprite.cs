using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class _1UpSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(260, 114, 18, 18)
                });

        }
        public override void Load(ContentManager content)
        {

            Source.Load(content, "items");
        }

    }
}
