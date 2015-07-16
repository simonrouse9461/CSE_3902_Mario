using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class CrouchingBigMarioSprite : SpriteKernelNew
    {
        public CrouchingBigMarioSprite()
        {
            AddSource(
                MarioSpriteVersion.Normal,
                "mario-luigi",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(9, 59, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Fire,
                "mario-luigi",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(185, 59, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Black,
                "mario-luigi",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(9, 147, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Red,
                "mario-luigi",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(185, 147, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Green,
                "mario-luigi",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(9, 235, 16, 22), Orientation.Right}
                });
            AddSource(
                MarioSpriteVersion.Luigi,
                "mario-luigi",
                new SortedList<Rectangle, Orientation>
                {
                    {new Rectangle(185, 235, 16, 22), Orientation.Right}
                });
        }
    }
}