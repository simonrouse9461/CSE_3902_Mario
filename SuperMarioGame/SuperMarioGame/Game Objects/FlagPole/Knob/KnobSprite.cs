using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class KnobSprite : SpriteKernel
    {
        public KnobSprite()
        {
            AddSource("large-objects", new Rectangle(261, 594, 8, 8), Orientation.Default);
        }    
    }
}
