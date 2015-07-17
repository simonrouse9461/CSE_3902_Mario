using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class UpsideDownGoombaSprite : SpriteKernel
    {
        public UpsideDownGoombaSprite()
        {
            ImageFile.Default = "enemies";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(330, 217, 16, 16)
                }
            };
        }
    }
}
