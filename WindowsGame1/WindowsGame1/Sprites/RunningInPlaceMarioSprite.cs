using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{

    public class RunningInPlaceMarioSprite : SpriteKernal
    {
        public override void Initialize()
        {
            // Source parameters
            int TotalFrames = 3;
            Vector2 StartCoordinate = new Vector2(230, 50);
            Vector2 EndCoordinate = new Vector2(322, 85);

            // Animation parameters
            int Period = 3;

            Source = new SingleLineSpriteSource(StartCoordinate, EndCoordinate, TotalFrames);
            Animation = new SpriteAnimation(Period,
                phase =>
                {
                    int[] FrameSequence = { 2, 1, 0 };
                    return FrameSequence[phase];
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "mario");
        }
    }
}
