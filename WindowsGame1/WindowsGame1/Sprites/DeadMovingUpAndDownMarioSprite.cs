using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{

    public class DeadMovingUpAndDownMarioSprite : SpriteKernal
    {
        public override void Initialize()
        {
            // Source parameters
            Vector2 StartCoordinate = new Vector2(0, 16);
            Vector2 EndCoordinate = new Vector2(14, 29);

            // Animation parameters
            int Period = 8;
            int DisplacementStages = 5;

            Source = new SingleLineSpriteSource(StartCoordinate, EndCoordinate);
            Animation = new SpriteAnimation(Period, null, DisplacementStages,
                phase =>
                {
                    int[] DisplacementSequence = { 0, 1, 2, 3, 4, 3, 2, 1 };
                    return DisplacementSequence[phase];
                },
                stage =>
                {
                    Vector2 TotalDisplacement = new Vector2(0, 20);
                    return stage * TotalDisplacement / DisplacementStages;
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "mario");
        }
    }
}