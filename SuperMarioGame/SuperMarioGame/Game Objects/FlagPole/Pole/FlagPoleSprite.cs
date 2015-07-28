using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class FlagPoleSprite : SpriteKernelNew
    {
        public FlagPoleSprite()
        {
            AddSource("large-objects", new Rectangle(264, 730, 2, 16), Orientation.Default);
        }    
    }
}
