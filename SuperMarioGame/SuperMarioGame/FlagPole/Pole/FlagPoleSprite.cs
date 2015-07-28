using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class FlagPoleSprite : SpriteKernelNew
    {
        public FlagPoleSprite() : base(FlagPoleSpriteVersion.Overworld)
        {

            AddSource(
                FlagPoleSpriteVersion.Overworld,
                "misc",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(261,594,8,152), Orientation.Default},
                });
            
        }    
    }
}
