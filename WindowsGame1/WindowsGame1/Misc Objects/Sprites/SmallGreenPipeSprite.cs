using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class SmallGreenPipeSprite : SpriteKernel
    {

        public SmallGreenPipeSprite()
        {
            ImageFile.Default = "pipes green";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(309, 101, 30, 31)
                }
            };
        }
    }
}
