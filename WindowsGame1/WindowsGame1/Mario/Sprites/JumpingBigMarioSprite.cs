using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class JumpingBigMarioSprite : SpriteKernelNew
    {
        public JumpingBigMarioSprite()
        {
            AddSource(
                MarioSpriteVersion.Normal,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(152, 46, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(328, 46, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Black,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(152, 134, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Red,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(328, 134, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Green,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(152, 222, 16, 32), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(328, 222, 16, 32), Orientation.Right}
                });
        }
    }
}