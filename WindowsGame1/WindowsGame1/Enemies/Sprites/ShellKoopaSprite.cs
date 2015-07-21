using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace MarioGame
{
    public class ShellKoopaSprite : SpriteKernel
    {
        public ShellKoopaSprite()
        {
            ImageFile.Default = "enemies";
            Source.Default = new SpriteSource
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(360, 4, 18, 15)
                }
            };
        }
    }
}
