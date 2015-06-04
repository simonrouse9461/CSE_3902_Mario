﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockSprite : SpriteKernel
    {
        protected override void Initialize()
        {

            Vector2 startCoordinate = new Vector2(0, 0);
            Vector2 endCoordinate = new Vector2(16, 16);
            const int period = 1;

            Source = new SpriteSource(startCoordinate, endCoordinate);
            Animation = new SpriteAnimation(null, period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "destructibleblock");
        }

    }
}