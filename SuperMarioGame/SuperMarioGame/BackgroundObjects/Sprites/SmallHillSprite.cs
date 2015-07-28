using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class SmallHillSprite : SpriteKernelNew
    {
        public SmallHillSprite()
        {
            AddSource("large-objects", new Rectangle(168, 21, 48, 19), Orientation.Default);
        }
    }
}
