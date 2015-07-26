using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class FlyingSuperFireballSprite : SpriteKernelNew
    {
        public FlyingSuperFireballSprite()
        {
            AddSource(
                "enemies",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(101, 253, 24, 8), Orientation.Left},
                    {new Rectangle(131, 253, 24, 8), Orientation.Left}
                });
            SetAnimation(Orientation.Right, new[]
                {
                    SpriteTransformation.Right(0, SpriteEffects.None, 0, null, 1f),
                    SpriteTransformation.Right(1, SpriteEffects.None, 0, null, 1f)
                }
            );
        }
    }
}
