using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class CastleSprite : SpriteKernelNew
    {

        public CastleSprite() 
        {

            AddSource(
                
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(272, 218, 80, 80), Orientation.Default},
                });
            
        }
    }
}
