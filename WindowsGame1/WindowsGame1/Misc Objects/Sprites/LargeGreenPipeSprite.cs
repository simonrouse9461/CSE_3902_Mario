using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class LargeGreenPipeSprite : SpriteKernel
    {
        public LargeGreenPipeSprite()
        {
            ImageFile.Default = "pipes green";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(230, 69, 30, 63)
                }
            };
        }
    }
}
