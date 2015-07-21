using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class IndestructibleBlockSprite : SpriteKernelNew
    {

        public IndestructibleBlockSprite() : base(IndestructibleBlockSpriteVersion.Overworld)
        {
            
            AddSource(
                IndestructibleBlockSpriteVersion.Overworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(373, 142, 16, 16), Orientation.Default}
                });

            AddSource(
                IndestructibleBlockSpriteVersion.Underworld,
                "misc_sprites",
                new OrderedPairs<Rectangle, Orientation>{
                    {new Rectangle(393, 142, 16, 16), Orientation.Default}
                }
                );
        }
    }
}
