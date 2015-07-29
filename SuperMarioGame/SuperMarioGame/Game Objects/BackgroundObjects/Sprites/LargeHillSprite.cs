using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class LargeHillSprite : SpriteKernel
    {
        public LargeHillSprite()
        {
            AddSource("large-objects", new Rectangle(80, 5, 80, 35), Orientation.Default);
        }
    }
}
