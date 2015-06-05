using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class JumpingLeftFMarioSprite: SpriteKernel
    {
        protected override void Initialize()
        {
            // Source parameters
            const int totalFrames = 8;
            Vector2 startCoordinate = new Vector2(0, 155);
            Vector2 endCoordinate = new Vector2(200, 190);

            // Animation parameters
            const int period = 8;

            Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
                phase =>
                {
                    int[] frameSequence = {7,6,5,4,3,2,1,0};
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