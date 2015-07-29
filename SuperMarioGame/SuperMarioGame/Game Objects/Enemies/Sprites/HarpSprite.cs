using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class HarpSprite : SpriteKernel
    {
        public HarpSprite()
        {
            AddSource("harp", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(4, 1, 51, 73), Orientation.Default}
            });
        }
    }
}
