using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class CrouchingLeftFireMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            base.Initialize();

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(0, 127, 16, 22)
                });
            Animation = new PeriodicFunction<int>();
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}