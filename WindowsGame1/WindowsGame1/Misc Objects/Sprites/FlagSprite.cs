using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class FlagSprite : SpriteKernel
    {

        public FlagSprite()
        {
            ImageFile.Default = "misc";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(249,594,20,152)
                }
            };
        }    
    }
}
