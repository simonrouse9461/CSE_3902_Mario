using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class FlagPoleSprite : SpriteKernelNew
    {

        public FlagPoleSprite() : base(FlagSpriteVersion.Overworld)
        {

            AddSource(
                FlagSpriteVersion.Overworld,
                "misc",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(261,594,8,152), Orientation.Default},
                });
            
        }    
    }
}
