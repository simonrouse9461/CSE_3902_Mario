using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class WalkingGoombaSprite : SpriteKernelNew
    {
        public WalkingGoombaSprite()
        {
            AddSource("enemies", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(0, 4, 16, 16), Orientation.Default},
                {new Rectangle(30, 4, 16, 16), Orientation.Default},
            });
            SetAnimation(new []
            {
                new SpriteTransformation(0), 
                new SpriteTransformation(1)
            });
        }
    }
}
