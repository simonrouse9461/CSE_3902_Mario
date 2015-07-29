using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class PipeHeadSprite : SpriteKernelNew
    {
        public PipeHeadSprite()
        {
            AddSource("large-object", new Rectangle(304, 416, 32, 16));
        }
    }
}
