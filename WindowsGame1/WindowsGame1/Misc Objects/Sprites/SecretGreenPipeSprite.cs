using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class SecretGreenPipeSprite : SpriteKernel
    {

        public SecretGreenPipeSprite()
        {
            ImageFile.Default = "pipes green";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(83, 4, 62, 128)
                }
            };
        }
    }
}
