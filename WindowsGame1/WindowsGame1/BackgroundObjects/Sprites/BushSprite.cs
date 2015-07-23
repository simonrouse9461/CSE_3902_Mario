using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class BushSprite : SpriteKernel
    {
        public BushSprite()
        {
            ImageFile.Default = "scenery";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(183, 144, 34, 16)
                }
            };
        }
    }
}
