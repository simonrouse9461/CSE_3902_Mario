using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class DeadGoombaSprite : SpriteKernel
    {
        public DeadGoombaSprite()
        {
            ImageFile.Default = "enemies";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(60, 8, 16, 8)
                }
            };
        }
    }
}
