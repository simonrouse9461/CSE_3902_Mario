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
                {new Rectangle(150, 0, 16, 24), Orientation.Left},
                {new Rectangle(180, 0, 16, 23), Orientation.Left}
            });
            SetAnimation(new[]
            {
                new SpriteTransformation(0),
                new SpriteTransformation(1)
            });
        }
    }
}
