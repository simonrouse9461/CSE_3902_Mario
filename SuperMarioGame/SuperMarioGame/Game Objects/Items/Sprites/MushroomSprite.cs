﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class MushroomSprite : SpriteKernel
    {
        public MushroomSprite()
        {

            AddSource(
                "items",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(183, 33, 18, 18), Orientation.Default},
                });
        }
    }
}
