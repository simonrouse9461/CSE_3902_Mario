using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
namespace WindowsGame1
{
    public class QuestionBlockSprite : SpriteKernelNew
    {
        
        protected override void Initialize()
        {
            
            const int period = 3;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(0, 0, 16, 16),
                    new Rectangle(16, 0, 16, 16),
                    new Rectangle(32, 0, 16, 16)
                });
            Animation = new SpriteAnimation(
            phase => 
            {
                int[] frameSequence = {0, 1, 2};
                return frameSequence[phase];
            },
            period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "blocks");
        }
    }
}
