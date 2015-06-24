using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class QuestionBlockSprite : SpriteKernelNew
    {
        public QuestionBlockSprite(){
            const int period = 3;
            ImageFile.Default = "blocks";
            Source.Default = new SpriteSourceNew{
                Coordinates = new Collection<Rectangle>{
                    new Rectangle(0,0,16,16),
                    new Rectangle(16,0,16,16),
                    new Rectangle(32,0,16,16)
                }
            };
            Animation.Default = new PeriodicFunction<int>(
            phase =>
            {
                int[] frameSequence = { 0, 0, 1, 1, 2, 2 };
                return frameSequence[phase];
            },
            period);
        }
        

            
    }
}
