using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class CrouchingLeftFireMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(0, 127, 16, 22)
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}