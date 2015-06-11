using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace WindowsGame1
{
    public class ShellKoopaSprite : SpriteKernelNew
    {

        protected override void Initialize()
        {
            //const int totalFrames = 1;

            //Vector2 startCoordinate = new Vector2(355, 0);
            //Vector2 endCoordinate = new Vector2(380, 18);
            const int period = 1;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(360, 4, 18, 15)
                });
            //Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
                phase =>
                {
                    int[] frameSequence = { 0 };
                    return frameSequence[phase];
                },
                period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "enemies");
        }
    }
}
