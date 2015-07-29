using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class ExplodingTinyFireballSprite : SpriteKernel
    {
        public ExplodingTinyFireballSprite()
        {
            AddSource("misc_sprites", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(360, 946, 8, 8), Orientation.Default},
                {new Rectangle(372, 943, 12, 14), Orientation.Default},
                {new Rectangle(388, 942, 16, 16), Orientation.Default}
            });
            SetAnimation(new []
            {
                SpriteTransformation.Center(0),
                SpriteTransformation.Center(1), 
                SpriteTransformation.Center(2)
            });
        }
    }
}
