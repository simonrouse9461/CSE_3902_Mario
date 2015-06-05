using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class JumpingRightFMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            // Source parameters
            const int totalFrames = 8;
            Vector2 startCoordinate = new Vector2(200, 155);
            Vector2 endCoordinate = new Vector2(405, 190);

            // Animation parameters
            const int period = 8;

            Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
                phase =>
                {
                    int[] frameSequence = {0,1,2,3,4,5,6,7};
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