using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CastleSprite : SpriteKernel
    {
        public CastleSprite()
        {
            AddSource("misc_sprites", new Rectangle(272, 218, 80, 80), Orientation.Default);
        }
    }
}
