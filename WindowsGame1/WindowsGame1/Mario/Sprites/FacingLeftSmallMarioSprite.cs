using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class FacingLeftSmallMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            base.Initialize();

            const int period = 1;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(181, 0, 13, 16)
                });
            Animation = new PeriodicFunction<int>(null, period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}