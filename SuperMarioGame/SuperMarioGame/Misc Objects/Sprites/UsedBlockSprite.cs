using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class UsedBlockSprite : SpriteKernelNew
    {
        public UsedBlockSprite()
            : base(UsedBlockSpriteVersion.UsedOver)
        {

            AddSource(
                UsedBlockSpriteVersion.UsedOver,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(373, 84, 16, 16), Orientation.Default},
                });

            AddSource(
                UsedBlockSpriteVersion.UsedUnder,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(394, 84, 16, 16), Orientation.Default},
                }
                );
        }
    }
}
