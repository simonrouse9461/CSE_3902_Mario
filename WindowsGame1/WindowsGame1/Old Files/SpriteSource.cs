using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class SpriteSource
    {
        public Texture2D Texture { get; private set; }
        public Collection<Rectangle> Coodinates { get; private set; }

        public SpriteSource(Collection<Rectangle> coodinates)
        {
            Coodinates = coodinates;
        }

        public void Load(ContentManager content, string image)
        {
            Texture = content.Load<Texture2D>(image);
        }
    }
}