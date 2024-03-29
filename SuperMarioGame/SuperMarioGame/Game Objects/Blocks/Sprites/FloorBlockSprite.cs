﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class FloorBlockSprite : SpriteKernel
    {

        public FloorBlockSprite()
            : base(FloorBlockSpriteVersion.Overworld)
        {

            AddSource(
                FloorBlockSpriteVersion.Overworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(373, 124, 16, 16), Orientation.Default},
                });

            AddSource(
                FloorBlockSpriteVersion.Underworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(393, 124, 16, 16), Orientation.Default},
                }
                );
        }
    }
}
