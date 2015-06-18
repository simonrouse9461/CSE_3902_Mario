using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class QuestionBlockSprite : SpriteKernel
    {
        
        protected override void Initialize()
        {
            const int period = 3;

            Source = new SpriteSource(
                new Collection<Rectangle>
                {
                    new Rectangle(0, 0, 16, 16),
                    new Rectangle(16, 0, 16, 16),
                    new Rectangle(32, 0, 16, 16)
                });
            Animation = new PeriodicFunction<int>(
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
