using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class CrouchingRightBigMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(389, 57, 16, 22),
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}