using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public struct SpriteSource
    {
        // Kernal properties
        public Texture2D Texture;
        public Vector2 StartCoordinate;
        public Vector2 EndCoordinate;
        public int TotalFrames;

        // Read-only properties
        public int Width
        {
            get { return (int) (EndCoordinate.X - StartCoordinate.X)/TotalFrames; }
        }

        public int Height
        {
            get { return (int) (EndCoordinate.Y - StartCoordinate.Y); }
        }

        // Constructor
        public SpriteSource(Vector2 start, Vector2 end, int frames = 1)
        {
            StartCoordinate = start;
            EndCoordinate = end;
            TotalFrames = frames;
            Texture = null;
        }

        // Load the sprite image
        public void Load(ContentManager content, string image)
        {
            Texture = content.Load<Texture2D>(image);
        }
    }
}