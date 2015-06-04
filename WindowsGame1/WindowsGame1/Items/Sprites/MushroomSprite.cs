﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class MushroomSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            const int totalFrames = 1;
            Vector2 startCoordinate = new Vector2(0, 0);
            Vector2 endCoordinate = new Vector2(25, 25);
            const int period = 1;

            Source = new SpriteSource(startCoordinate, endCoordinate, totalFrames);
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

            Source.Load(content, "Mushroom");
        }

    }
}
