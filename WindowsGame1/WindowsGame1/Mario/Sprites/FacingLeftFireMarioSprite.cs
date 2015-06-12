﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class FacingLeftFireMarioSprite : SpriteKernelNew
    {
        protected override void Initialize()
        {
            // Animation parameters
            const int period = 1;

            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(180, 122, 16, 32)
                });
            Animation = new PeriodicFunction<int>(null, period);
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}