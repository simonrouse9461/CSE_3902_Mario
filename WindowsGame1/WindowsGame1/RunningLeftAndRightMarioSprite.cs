using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class RunningLeftAndRightMarioSprite : ISpriteKernal
    {
        public override void Initialize()
        {
            // Source parameters
            int TotalFrames = 8;
            Vector2 StartCoordinate = new Vector2(83, 50);
            Vector2 EndCoordinate = new Vector2(322, 85);
            
            // Animation parameters
            int Period = 16;
            int DisplacementStages = 8;

            Source = new SingleLineSpriteSource(StartCoordinate, EndCoordinate, TotalFrames);
            Animation = new SpriteAnimation(Period,
                phase =>
                {
                    int[] FrameSequence = { 7, 6, 5, 7, 6, 5, 4, 3, 0, 1, 2, 0, 1, 2, 3, 4 };
                    return FrameSequence[phase];
                }, DisplacementStages,
                phase =>
                {
                    int[] DisplacementSequence = { 1, 2, 3, 4, 5, 6, 7, 7, 6, 5, 4, 3, 2, 1, 0, 0 };
                    return DisplacementSequence[phase];
                },
                stage =>
                {
                    Vector2 TotalDisplacement = new Vector2(40, 0);
                    return stage * TotalDisplacement / DisplacementStages;
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "mario");
        }
    }
}
