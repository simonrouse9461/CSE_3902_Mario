using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class GreenPipeSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            Source = new SpriteSource(
                new Collection<Rectangle>
                {
                    new Rectangle(230, 385, 32, 64)
                });
        }
        public override void Load(ContentManager content)
        {

            Source.Load(content, "misc");
        }

    }
}
