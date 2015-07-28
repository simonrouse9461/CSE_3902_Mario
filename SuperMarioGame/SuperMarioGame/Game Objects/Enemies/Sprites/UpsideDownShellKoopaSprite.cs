using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace SuperMario
{
    public class UpsideDownShellKoopaSprite : SpriteKernelNew
    {
        public UpsideDownShellKoopaSprite()
        {
            AddSource("enemies", new OrderedPairs<Rectangle, Orientation>
            {
                {new Rectangle(352, 221, 18, 15), Orientation.Default}
            });
        }
    }
}
