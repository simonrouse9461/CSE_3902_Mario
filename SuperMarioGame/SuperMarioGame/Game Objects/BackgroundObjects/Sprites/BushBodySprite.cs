using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class BushBodySprite : SpriteKernel
    {
        public BushBodySprite()
        {
            AddSource("large-objects", new Rectangle(232, 24, 16, 16), Orientation.Default);
        }
    }
}
