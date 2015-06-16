using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class GreenPipeSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            Source = new SpriteSource(new List<Rectangle>
            {
                new Rectangle(0, 0, 30, 61)
            });
        }
        public override void Load(ContentManager content)
        {

            Source.Load(content, "single green pipe");
        }

    }
}
