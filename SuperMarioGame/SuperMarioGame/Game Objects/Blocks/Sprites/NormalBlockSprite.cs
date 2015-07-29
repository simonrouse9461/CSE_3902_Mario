using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class NormalBlockSprite : SpriteKernel
    {
        public NormalBlockSprite()
            : base(NormalBlockSpriteVersion.Overworld)
        {

            AddSource(
                NormalBlockSpriteVersion.Overworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(373, 102, 16, 16), Orientation.Default}
                });

            AddSource(
                NormalBlockSpriteVersion.Underworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(393, 102, 16, 16), Orientation.Default}
                }
                );
        }
    }
}
