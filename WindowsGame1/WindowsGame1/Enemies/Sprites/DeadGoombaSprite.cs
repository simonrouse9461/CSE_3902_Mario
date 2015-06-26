using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
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
                    new Rectangle(60, 7, 16, 10)
                }
            };
        }
    }
}
