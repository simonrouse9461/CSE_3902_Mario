using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class DestroyedBlockSprite : SpriteKernel
    {


        protected override void Initialize()
        {
            Source = new SpriteSource(
                new Collection<Rectangle>
                {
                    new Rectangle(0,0,0,0)
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "blocks");
        }
    }
}
