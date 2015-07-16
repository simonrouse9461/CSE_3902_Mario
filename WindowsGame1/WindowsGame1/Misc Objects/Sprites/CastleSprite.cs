using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class CastleSprite : SpriteKernel
    {

        public CastleSprite()
        {
            ImageFile.Default = "misc";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(247, 863, 80, 80)
                }
            };
        }
    }
}
