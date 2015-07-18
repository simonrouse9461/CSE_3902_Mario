using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class SpriteSourceNew
    {
        public string ImageFile { get; private set; }
        public Texture2D Texture { get; private set; }
        public OrderedPairs<Rectangle, Orientation> FrameData { get; set; }

        public SpriteSourceNew(string source)
        {
            ImageFile = source;
        }

        public void Load(ContentManager content)
        {
            Texture = content.Load<Texture2D>(ImageFile);
        }
    }
}