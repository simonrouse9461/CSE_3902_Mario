using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public class SecretGreenPipeSprite : SpriteKernelNew
    {
        public SecretGreenPipeSprite()
        {
            AddSource("pipes green", new Rectangle(83, 4, 62, 128));
        }
    }
}
