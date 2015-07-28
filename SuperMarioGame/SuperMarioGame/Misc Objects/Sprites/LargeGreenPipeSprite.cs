using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class LargeGreenPipeSprite : SpriteKernelNew
    {
        public LargeGreenPipeSprite()
        {
            AddSource("pipes green", new Rectangle(229, 68, 32, 64));
        }
    }
}
