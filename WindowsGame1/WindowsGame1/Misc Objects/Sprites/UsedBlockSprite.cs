using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class UsedBlockSprite : SpriteKernelNew
    {
        public UsedBlockSprite()
            : base(BlockSpriteVersion.BlockVersion.Overworld)
        {

            AddSource(
                BlockSpriteVersion.BlockVersion.Overworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(373, 84, 16, 16), Orientation.Default},
                });

            AddSource(
                BlockSpriteVersion.BlockVersion.Underworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(394, 84, 16, 16), Orientation.Default},
                }
                );
        }
    }
}
