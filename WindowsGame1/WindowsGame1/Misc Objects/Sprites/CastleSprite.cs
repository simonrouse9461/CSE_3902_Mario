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
                CastleSpriteVersion.Overworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(247, 863, 80, 80), Orientation.Default},
                });
            
        }
    }
}
