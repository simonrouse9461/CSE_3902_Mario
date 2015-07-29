using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class SpriteSource
    {
        public string ImageFile { get; private set; }
        public Texture2D Texture { get; private set; }
        public OrderedPairs<Rectangle, Orientation> FrameData { get; set; }

        public SpriteSource(string source)
        {
            ImageFile = source;
        }

        public void Load(ContentManager content)
        {
            Texture = content.Load<Texture2D>(ImageFile);
        }
    }
}