using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class MediumGreenPipeSprite : SpriteKernel
    {

        public MediumGreenPipeSprite()
        {
            ImageFile.Default = "pipes green";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(270, 84, 32, 48)
                }
            };
        }
    }
}
