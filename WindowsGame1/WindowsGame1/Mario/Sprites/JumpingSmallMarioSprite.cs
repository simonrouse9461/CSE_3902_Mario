using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class JumpingSmallMarioSprite : SpriteKernelNew
    {
        public JumpingSmallMarioSprite()
        {
            AddSource(
                MarioSpriteVersion.Normal,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(124, 7, 17, 16), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(300, 7, 17, 16), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Black,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(124, 95, 17, 16), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Red,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(300, 95, 17, 16), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Green,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(124, 183, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(300, 183, 16, 22), Orientation.Right}
                });
        }
    }
}