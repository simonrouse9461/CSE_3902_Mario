using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class NormalBlockSprite : SpriteKernelNew
    {
        public NormalBlockSprite()
            : base(BlockSpriteVersion.BlockVersion.Overworld)
        {

            AddSource(
                BlockSpriteVersion.BlockVersion.Overworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(373, 102, 16, 16), Orientation.Default}
                });

            AddSource(
                BlockSpriteVersion.BlockVersion.Underworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(393, 102, 16, 16), Orientation.Default}
                }
                );
        }
    }
}
