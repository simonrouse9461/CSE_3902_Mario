using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class SmallGreenPipeSprite : SpriteKernelNew
    {
        public SmallGreenPipeSprite()
        {
            AddSource("pipes green", new Rectangle(308, 100, 32, 32));
        }
    }
}
