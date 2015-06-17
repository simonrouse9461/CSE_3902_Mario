using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class HillSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(86, 5, 80, 35)
                });
           
        }
        public override void Load(ContentManager content)
        {
            Source.Load(content, "misc");
        }

    }
}
