using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class MediumGreenPipeSprite : SpriteKernelNew
    {
        public MediumGreenPipeSprite()
        {
            AddSource("pipes green", new Rectangle(270, 84, 32, 48));
        }
    }
}
