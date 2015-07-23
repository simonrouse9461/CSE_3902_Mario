using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace SuperMario
{
    public class UpsideDownShellKoopaSprite : SpriteKernel
    {
        public UpsideDownShellKoopaSprite()
        {
            ImageFile.Default = "enemies";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(352, 221, 18, 15)
                }
            };
        }
    }
}
