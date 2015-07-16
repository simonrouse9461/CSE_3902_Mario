using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class ShootingMarioSprite : SpriteKernelNew
    {
        public ShootingMarioSprite()
        {
            AddSource(
                MarioSpriteVersion.Normal,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(9, 59, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(185, 59, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Black,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(9, 147, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Red,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(185, 147, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Green,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(9, 235, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(185, 235, 16, 22), Orientation.Right}
                });
        }
    }
}
