﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class RunningLeftBMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            // Source parameters
            const int totalFrames = 3;
            Vector2 startCoordinate = new Vector2(80, 50);
            Vector2 endCoordinate = new Vector2(170, 85);

            // Animation parameters
            const int period = 3;

            Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
            Animation = new SpriteAnimation(
                phase =>
                {
                    int[] frameSequence = {0,1,2};
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