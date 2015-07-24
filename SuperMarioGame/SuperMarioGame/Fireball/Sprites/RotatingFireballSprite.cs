using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class RotatingFireballSprite : SpriteKernelNew
    {
        public RotatingFireballSprite()
        {
            AddSource("misc_sprites", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(313, 945, 8, 8), Orientation.Right}
            });
            SetAnimation(new[]
            {
                new SpriteTransformation(0),
                new SpriteTransformation(0, SpriteEffects.None, Math.PI/2), 
                new SpriteTransformation(0, SpriteEffects.FlipVertically),  
                new SpriteTransformation(0, SpriteEffects.None, -Math.PI/2), 
            });
        }
    }
}
