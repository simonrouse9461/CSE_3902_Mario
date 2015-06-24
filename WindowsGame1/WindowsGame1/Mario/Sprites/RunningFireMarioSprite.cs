using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class RunningFireMarioSprite : SpriteKernelNew
    {
        public RunningFireMarioSprite()
        {
            const int period = 3;

            ImageFile.Default = "Mario";
            Source.Left = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(102, 123, 16, 30),
                    new Rectangle(128, 122, 14, 31),
                    new Rectangle(152, 122, 16, 32)
                }
            };
            Animation.Left = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {0, 1, 2};
                    return frameSequence[phase];
                }, 
                period);
            Source.Right = new SpriteSourceNew
            {
                Coordinates = new Collection<Rectangle>
                {
                    new Rectangle(237, 122, 16, 32),
                    new Rectangle(263, 122, 14, 31),
                    new Rectangle(287, 123, 16, 30)
                }
            };
            Animation.Right = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = {2, 1, 0};
                    return frameSequence[phase];
                },
                period);
        }
    }
}