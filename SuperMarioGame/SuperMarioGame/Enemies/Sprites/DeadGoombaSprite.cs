﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class DeadGoombaSprite : SpriteKernelNew
    {
        public DeadGoombaSprite()
        {
            AddSource("enemies", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(60, 8, 16, 8), Orientation.Default}
            });
        }
    }
}
