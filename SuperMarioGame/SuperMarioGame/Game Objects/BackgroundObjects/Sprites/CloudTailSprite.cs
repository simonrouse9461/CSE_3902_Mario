using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CloudTailSprite : SpriteKernel
    {
        public CloudTailSprite()
        {
            AddSource("large-objects", new Rectangle(200, 72, 16, 24), Orientation.Default);
        }
    }
}
