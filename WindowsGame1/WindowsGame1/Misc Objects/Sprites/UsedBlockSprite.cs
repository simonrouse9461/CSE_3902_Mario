using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
namespace WindowsGame1
{
    public class UsedBlockSprite : SpriteKernelNew
    {
        protected override void Initialize(){
        Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(0, 32, 16, 16)
                });
        Animation = new PeriodicFunction(null, 0);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "blocks");
        }

    }
}
