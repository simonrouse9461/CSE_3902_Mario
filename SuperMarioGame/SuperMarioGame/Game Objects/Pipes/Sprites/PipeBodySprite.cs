using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class PipeBodySprite : SpriteKernel
    {
        public PipeBodySprite()
        {
            AddSource("large-objects", new Rectangle(306, 432, 28, 16));
        }
    }
}
