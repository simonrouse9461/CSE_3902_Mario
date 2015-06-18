﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class SpriteSource
    {
        // Kernal properties
        public Texture2D Texture { get; set; }
        public List<Rectangle> Coodinates { get; set; }

        // Constructor
        public SpriteSource(List<Rectangle> coodinates)
        {
            Coodinates = coodinates;
        }

        // Load the sprite image
        public void Load(ContentManager content, string image)
        {
            Texture = content.Load<Texture2D>(image);
        }
    }
}