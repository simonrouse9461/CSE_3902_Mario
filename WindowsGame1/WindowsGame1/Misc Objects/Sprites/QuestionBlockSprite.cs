using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class QuestionBlockSprite : SpriteKernel
    {
        public QuestionBlockSprite(){
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSource{
                Coordinates = new Collection<Rectangle>{
                    new Rectangle(0,0,16,16),
                    new Rectangle(16,0,16,16),
                    new Rectangle(32,0,16,16)
                }
            };
            Animation.Default = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {1, 2, 1, 0, 0, 0};
                    return frameSequence[phase];
                }, 6);
        }        
    }
}
