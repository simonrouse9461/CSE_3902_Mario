using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class FlagSprite : SpriteKernel
    {
        public FlagSprite()
        {
            AddSource("misc_sprites", new Rectangle(432, 84, 16, 16), Orientation.Default);
        }    
    }
}
