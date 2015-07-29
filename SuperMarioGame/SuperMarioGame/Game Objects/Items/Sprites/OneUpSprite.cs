using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class OneUpSprite : SpriteKernel
    {
        public OneUpSprite()
        {

            AddSource(
                "items",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(214, 34, 16, 16), Orientation.Default},
                });
        }
    }
}
