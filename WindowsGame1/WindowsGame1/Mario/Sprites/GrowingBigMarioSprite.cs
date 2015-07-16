using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class GrowingBigMarioSprite : SpriteKernelNew
    {
        public GrowingBigMarioSprite()
        {
            AddSource(
                MarioSpriteVersion.Normal,
                "characters",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(277, 44, 12, 16), Orientation.Right},
                    {new Rectangle(258, 36, 16, 24), Orientation.Right},
                    {new Rectangle(258, 1, 16, 32), Orientation.Right},
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