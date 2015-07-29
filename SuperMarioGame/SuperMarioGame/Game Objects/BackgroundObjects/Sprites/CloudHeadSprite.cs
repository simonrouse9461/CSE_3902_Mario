using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CloudHeadSprite : SpriteKernel
    {
        public CloudHeadSprite()
        {
            AddSource("large-objects", new Rectangle(136, 72, 16, 24), Orientation.Default);
        }
    }
}
