using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class FacingRightBigMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(209, 52, 16, 32)
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}