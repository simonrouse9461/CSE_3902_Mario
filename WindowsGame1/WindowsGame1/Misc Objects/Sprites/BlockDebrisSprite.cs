using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class BlockDebrisSprite : SpriteKernelNew
    {
        public BlockDebrisSprite()
            : base(BlockDebrisSpriteVersion.Overworld)
        {

            AddSource(
                BlockDebrisSpriteVersion.Overworld,
                "block debris",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(0, 0, 15, 15), Orientation.Default},
                    {new Rectangle(18, 0, 22, 21), Orientation.Default},
                    {new Rectangle(45, 0, 30, 22), Orientation.Default},
                    {new Rectangle(84, 0, 46, 27), Orientation.Default}
                });
            SetAnimation(new []
            {
                new SpriteTransformation(0),
                new SpriteTransformation(1),
                new SpriteTransformation(2),
                new SpriteTransformation(3)
            });
        }
    }
}
