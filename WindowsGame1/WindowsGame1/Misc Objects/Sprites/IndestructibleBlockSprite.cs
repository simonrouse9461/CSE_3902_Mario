using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class IndestructibleBlockSprite : SpriteKernelNew
    {

        public IndestructibleBlockSprite() : base(BlockSpriteVersion.BlockVersion.Overworld)
        {
            
            AddSource(
                BlockSpriteVersion.BlockVersion.Overworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(373, 142, 16, 16), Orientation.Default}
                });

            AddSource(
                BlockSpriteVersion.BlockVersion.Underworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(393, 142, 16, 16), Orientation.Default}
                }
                );
        }
    }
}
