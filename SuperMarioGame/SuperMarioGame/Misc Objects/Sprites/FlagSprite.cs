using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class FlagSprite : SpriteKernelNew
    {
        public FlagSprite() : base(FlagSpriteVersion.Overworld)
        {

            AddSource(
                FlagSpriteVersion.Overworld,
                "misc",
                new OrderedPairs<Rectangle, Orientation>
                {
                    {new Rectangle(279,598,16,16), Orientation.Default},
                });
            
        }    
    }
}
