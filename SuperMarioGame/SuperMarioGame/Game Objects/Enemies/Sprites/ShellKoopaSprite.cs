﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace SuperMario
{
    public class ShellKoopaSprite : SpriteKernel
    {
        public ShellKoopaSprite()
        {
            AddSource("enemies", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(360, 5, 16, 14), Orientation.Default}
            });
        }
    }
}
