using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class DeadMarioSprite : SpriteKernelNew
    {
        public DeadMarioSprite()
        {
            AddSource(
                MarioSpriteVersion.Normal, 
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(30, 9, 15, 14), Orientation.Default}
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(206, 9, 15, 14), Orientation.Default}
                });
            AddSource(
                MarioSpriteVersion.Black,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(30, 97, 15, 14), Orientation.Default}
                });
            AddSource(
                MarioSpriteVersion.Red,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(206, 97, 15, 14), Orientation.Default}
                });
            AddSource(
                MarioSpriteVersion.Green,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(30, 185, 15, 14), Orientation.Default}
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "MiscMario",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(206, 185, 15, 14), Orientation.Default}
                });
        }
    }
}