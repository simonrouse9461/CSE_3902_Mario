using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class SlipingSuperMarioSprite : SpriteKernelNew
    {
        public SlipingSuperMarioSprite()
            : base(MarioSpriteVersion.Normal)
        {
            var D = 48;

            var X0 = 193;
            var Y0 = 2;
            var W0 = 14;
            var H0 = 30;

            var X1 = 209;
            var Y1 = 5;
            var W1 = 14;
            var H1 = 27;

            AddSource(
                MarioSpriteVersion.Normal,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1, W1, H1), Orientation.Right},
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+D, W1, H1), Orientation.Right},
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+2*D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+2*D, W1, H1), Orientation.Right},
                });
            AddSource(
                MarioSpriteVersion.Black,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+3*D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+3*D, W1, H1), Orientation.Right},
                });
            AddSource(
                MarioSpriteVersion.Green,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+4*D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+4*D, W1, H1), Orientation.Right},
                });
            AddSource(
                MarioSpriteVersion.Red,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+5*D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+5*D, W1, H1), Orientation.Right},
                });
            SetAnimation(new[]
            {
                new SpriteTransformation(0), 
                new SpriteTransformation(1)
            });
        }
    }
}