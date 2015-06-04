using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{

    public class RunningRightFMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            // Source parameters
            const int totalFrames = 3;
            Vector2 startCoordinate = new Vector2(230, 120);
            Vector2 endCoordinate = new Vector2(305, 155);

            // Animation parameters
            const int period = 3;

            Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
                phase =>
                {
                    int[] frameSequence = { 2, 1, 0 };
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
