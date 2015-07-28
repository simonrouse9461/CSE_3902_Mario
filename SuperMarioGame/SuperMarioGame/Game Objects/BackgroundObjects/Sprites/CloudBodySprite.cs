using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CloudBodySprite : SpriteKernelNew
    {
        public CloudBodySprite()
        {
            AddSource("large-objects", new Rectangle(152, 72, 16, 24), Orientation.Default);
        }
    }
}
