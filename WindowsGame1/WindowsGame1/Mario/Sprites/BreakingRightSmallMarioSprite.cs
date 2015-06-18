using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class BreakingRightSmallMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(331, 0, 14, 16)
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        } 
    }
}