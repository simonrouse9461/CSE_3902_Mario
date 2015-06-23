using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class DeadMarioSprite : SpriteKernelNew
    {
        public DeadMarioSprite()
        {
            ImageFile.Default = "Mario";
            Source.Default = new SpriteSourceNew
            {
                Coodinates = new Collection<Rectangle>
                {
                    new Rectangle(0, 16, 15, 14)
                }
            };
        }
    }
}