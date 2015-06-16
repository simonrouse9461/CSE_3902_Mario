using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public struct SpriteSource
    {
        // Kernal properties
        public Texture2D Texture;
        public List<Rectangle> Coodinates; 
        private int TotalFrames;

        // Constructor
        public SpriteSource(List<Rectangle> coodinates)
        {
            Coodinates = coodinates;
            TotalFrames = coodinates.Count;
            Texture = null;
        }

        // Load the sprite image
        public void Load(ContentManager content, string image)
        {
            Texture = content.Load<Texture2D>(image);
        }
    }
}