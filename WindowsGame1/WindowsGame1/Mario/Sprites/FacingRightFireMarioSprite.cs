using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class FacingRightFireMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(209, 122, 16, 32)
                });
            Animation = new PeriodicFunction<int>();
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}