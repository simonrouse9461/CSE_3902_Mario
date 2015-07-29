using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class BushHeadSprite : SpriteKernel
    {
        public BushHeadSprite()
        {
            AddSource("large-objects", new Rectangle(216, 24, 16, 16), Orientation.Default);
        }
    }
}
