using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class MushroomSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            Source = new SpriteSource(
            new Collection<Rectangle>
            {
                new Rectangle(183, 33, 18, 18)
            });
        }
        public override void Load(ContentManager content)
        {
            Source.Load(content, "items");
        }

    }
}
