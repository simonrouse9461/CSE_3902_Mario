﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class SuperFireballSprite : SpriteKernelNew
    {

        public SuperFireballSprite()
        {

            AddSource(
                "enemies",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(101, 253, 24, 8), Orientation.Left},
                    {new Rectangle(131, 253, 24, 8), Orientation.Left}
                });

            AddSource(
                "enemies",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(161, 253, 24, 8), Orientation.Right},
                    {new Rectangle(191, 253, 24, 8), Orientation.Right}
                });
        }
    }
}
