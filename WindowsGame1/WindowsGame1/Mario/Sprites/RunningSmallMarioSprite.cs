using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame
{
    public class RunningSmallMarioSprite : SpriteKernelNew
    {
        public RunningSmallMarioSprite()
            : base(MarioSpriteVersion.Normal)
        {
            var D = 48;

            var X0 = 80;
            var Y0 = 32;
            var W0 = 15;
            var H0 = 16;

            var X1 = 99;
            var Y1 = 32;
            var W1 = 11;
            var H1 = 16;

            var X2 = 114;
            var Y2 = 33;
            var W2 = 13;
            var H2 = 15;

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
            SetAnimation(new[]
            {
                new SpriteTransformation(2), 
                new SpriteTransformation(1), 
                new SpriteTransformation(0)
            });
        }
    }
}