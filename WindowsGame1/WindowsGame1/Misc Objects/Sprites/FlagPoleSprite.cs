using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class FlagPoleSprite : SpriteKernel
    {

        public FlagPoleSprite()
        {
            ImageFile.Default = "misc";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(261,594,8,152)
                }
            };
        }    
    }
}
