using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class UpsideDownGoombaSprite : SpriteKernel
    {
        public UpsideDownGoombaSprite()
        {
            AddSource("enemies", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(330, 217, 16, 16), Orientation.Default}
            });
        }
    }
}
