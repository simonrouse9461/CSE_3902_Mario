using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class FloorBlockSprite : SpriteKernelNew
    {

        public FloorBlockSprite()
            : base(BlockSpriteVersion.BlockVersion.Overworld)
        {

            AddSource(
                BlockSpriteVersion.BlockVersion.Overworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(373, 124, 16, 16), Orientation.Default},
                });

            AddSource(
                BlockSpriteVersion.BlockVersion.Underworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(393, 124, 16, 16), Orientation.Default},
                }
                );
        }
    }
}
