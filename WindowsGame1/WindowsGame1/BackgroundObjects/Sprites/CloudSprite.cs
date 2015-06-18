using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class CloudSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            

            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(8, 344, 33, 24)
                });
           
        }
        public override void Load(ContentManager content)
        {
            Source.Load(content, "scenery");
        }

    }
}
