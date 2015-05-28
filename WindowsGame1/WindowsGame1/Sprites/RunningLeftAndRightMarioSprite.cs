using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class RunningLeftAndRightMarioSprite : SpriteKernel
    {
        public override void Initialize()
        {
            // Source parameters
            const int totalFrames = 8;
            Vector2 startCoordinate = new Vector2(83, 50);
            Vector2 endCoordinate = new Vector2(322, 85);

            // Animation parameters
            const int period = 16;

            Source = new SingleLineSpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
                phase =>
                {
                    int[] FrameSequence = {7, 6, 5, 7, 6, 5, 4, 3, 0, 1, 2, 0, 1, 2, 3, 4};
                    return FrameSequence[phase];
                }, 
                period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "mario");
        }
    }
}