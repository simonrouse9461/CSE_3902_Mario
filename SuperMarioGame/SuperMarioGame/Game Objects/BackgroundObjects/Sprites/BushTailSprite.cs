using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class BushTailSprite : SpriteKernelNew
    {
        public BushTailSprite()
        {
            AddSource("large-objects", new Rectangle(280, 24, 16, 16), Orientation.Default);
        }
    }
}
