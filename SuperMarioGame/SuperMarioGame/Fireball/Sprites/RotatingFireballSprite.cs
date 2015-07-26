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
            SetAnimation(Orientation.Right, new[]
            {
                SpriteTransformation.Right(0),
                SpriteTransformation.Right(0, SpriteEffects.None, Math.PI/2), 
                SpriteTransformation.Right(0, SpriteEffects.FlipVertically),  
                SpriteTransformation.Right(0, SpriteEffects.None, -Math.PI/2), 
            });
        }
    }
}
