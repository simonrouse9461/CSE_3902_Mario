using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class RunningBigMarioSprite : SpriteKernelNew
    {
        public RunningBigMarioSprite()
        {
            AddSource(
                MarioSpriteVersion.Normal,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(80, 49, 14, 31), Orientation.Right},
                    {new Rectangle(100, 49, 16, 30), Orientation.Right},
                    {new Rectangle(125, 48, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(256, 49, 14, 31), Orientation.Right},
                    {new Rectangle(276, 49, 16, 30), Orientation.Right},
                    {new Rectangle(301, 48, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Black,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(80, 137, 14, 31), Orientation.Right},
                    {new Rectangle(100, 137, 16, 30), Orientation.Right},
                    {new Rectangle(125, 136, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Red,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(256, 137, 14, 31), Orientation.Right},
                    {new Rectangle(276, 137, 16, 30), Orientation.Right},
                    {new Rectangle(301, 136, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Green,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(80, 225, 14, 31), Orientation.Right},
                    {new Rectangle(100, 225, 16, 30), Orientation.Right},
                    {new Rectangle(125, 224, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(256, 225, 14, 31), Orientation.Right},
                    {new Rectangle(276, 225, 16, 30), Orientation.Right},
                    {new Rectangle(301, 224, 16, 32), Orientation.Right}
                });
            SetAnimation(new []
            {
                new SpriteTransformation(1), 
                new SpriteTransformation(0), 
                new SpriteTransformation(2)
            });
        }
    }
}