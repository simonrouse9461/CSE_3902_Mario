using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame
{
    public class GrowingMarioSprite : SpriteKernelNew
    {
        public GrowingMarioSprite()
            : base(MarioSpriteVersion.Normal)
        {
            var D = 48;

            var X0 = 178;
            var Y0 = 32;
            var W0 = 12;
            var H0 = 16;

            var X1 = 320;
            var Y1 = 8;
            var W1 = 16;
            var H1 = 24;

            var X2 = 176;
            var Y2 = 0;
            var W2 = 16;
            var H2 = 32;

            AddSource(
                MarioSpriteVersion.Normal,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1, W1, H1), Orientation.Right},
                    {new Rectangle(X2, Y2, W2, H2), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+D, W1, H1), Orientation.Right},
                    {new Rectangle(X2, Y2+D, W2, H2), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+2*D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+2*D, W1, H1), Orientation.Right},
                    {new Rectangle(X2, Y2+2*D, W2, H2), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Black,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+3*D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+3*D, W1, H1), Orientation.Right},
                    {new Rectangle(X2, Y2+3*D, W2, H2), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Green,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+4*D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+4*D, W1, H1), Orientation.Right},
                    {new Rectangle(X2, Y2+4*D, W2, H2), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Red,
                "mario-luigi",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(X0, Y0+5*D, W0, H0), Orientation.Right},
                    {new Rectangle(X1, Y1+5*D, W1, H1), Orientation.Right},
                    {new Rectangle(X2, Y2+5*D, W2, H2), Orientation.Right}
                });
            SetAnimation(new []
            {
                new SpriteTransformation(0),
                new SpriteTransformation(1),
                new SpriteTransformation(0),
                new SpriteTransformation(1),
                new SpriteTransformation(0),
                new SpriteTransformation(1),
                new SpriteTransformation(2),
                new SpriteTransformation(0),
                new SpriteTransformation(1),
                new SpriteTransformation(2),
            });
        }
    }
}