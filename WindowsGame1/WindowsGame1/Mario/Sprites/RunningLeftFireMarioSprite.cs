using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class RunningLeftFireMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            // Animation parameters
            const int period = 3;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    //new Rectangle(77, 123, 16, 30),
                    new Rectangle(102, 123, 16, 30),
                    new Rectangle(128, 122, 14, 31),
                    new Rectangle(152, 122, 16, 32)
                });
            Animation = new SpriteAnimation(
                phase =>
                {
                    int[] frameSequence = { 0, 1, 2 };
                    return frameSequence[phase];
                }, 
                period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}