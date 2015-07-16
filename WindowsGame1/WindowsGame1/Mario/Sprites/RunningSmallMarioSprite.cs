using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class RunningSmallMarioSprite : SpriteKernelNew
    {
        public RunningSmallMarioSprite()
        {
            AddSource(
                MarioSpriteVersion.Normal,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(70, 7, 12, 16), Orientation.Right},
                    {new Rectangle(85, 8, 14, 15), Orientation.Right},
                    {new Rectangle(102, 7, 16, 16), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(246, 7, 12, 16), Orientation.Right},
                    {new Rectangle(261, 8, 14, 15), Orientation.Right},
                    {new Rectangle(278, 7, 16, 16), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Black,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(70, 95, 12, 16), Orientation.Right},
                    {new Rectangle(85, 96, 14, 15), Orientation.Right},
                    {new Rectangle(102, 95, 16, 16), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Red,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(246, 95, 12, 16), Orientation.Right},
                    {new Rectangle(261, 96, 14, 15), Orientation.Right},
                    {new Rectangle(278, 95, 16, 16), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Green,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(70, 183, 12, 16), Orientation.Right},
                    {new Rectangle(85, 184, 14, 15), Orientation.Right},
                    {new Rectangle(102, 183, 16, 16), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(246, 183, 12, 16), Orientation.Right},
                    {new Rectangle(261, 184, 14, 15), Orientation.Right},
                    {new Rectangle(278, 183, 16, 16), Orientation.Right}
                });
            SetAnimation(new[]
            {
                new SpriteTransformation(1), 
                new SpriteTransformation(2), 
                new SpriteTransformation(0)
            });
        }
    }
}