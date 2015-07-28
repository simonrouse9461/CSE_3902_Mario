using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class WalkingKoopaSprite : SpriteKernelNew
    {
        public WalkingKoopaSprite()
        {
            AddSource("enemies", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(149, 1, 18, 23), Orientation.Left},
                {new Rectangle(179, 1, 18, 23), Orientation.Left}
            });
            SetAnimation(new[]
            {
                new SpriteTransformation(0),
                new SpriteTransformation(1)
            });
        }
    }
}
