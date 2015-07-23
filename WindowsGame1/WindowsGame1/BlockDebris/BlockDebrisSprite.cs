using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public class BlockDebrisSprite : SpriteKernelNew
    {
        public BlockDebrisSprite()
            : base(BlockDebrisSpriteVersion.Brown)
        {

            AddSource(
                BlockDebrisSpriteVersion.Brown,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(432, 47, 8, 8), Orientation.Default},
                });
            SetAnimation(new []
            {
                new SpriteTransformation(0),
                new SpriteTransformation(0, SpriteEffects.FlipHorizontally)
            });
        }
    }
}
