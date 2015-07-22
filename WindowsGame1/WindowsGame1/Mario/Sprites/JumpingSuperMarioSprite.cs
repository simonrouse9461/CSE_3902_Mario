﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame
{
    public class JumpingSuperMarioSprite : SpriteKernelNew
    {
        public JumpingSuperMarioSprite()
            : base(MarioSpriteVersion.Normal)
        {
            var D = 48;

            var X = 144;
            var Y = 0;
            var W = 16;
            var H = 31;

            AddSource(
                MarioSpriteVersion.Normal,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X, Y, W, H), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X, Y+D, W, H), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X, Y+2*D, W, H), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Black,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X, Y+3*D, W, H), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Green,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X, Y+4*D, W, H), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Red,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X, Y+5*D, W, H), Orientation.Right}
                });
        }
    }
}