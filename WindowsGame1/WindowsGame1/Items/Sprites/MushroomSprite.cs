﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class MushroomSprite : SpriteKernelNew
    {

        protected override void Initialize()
        {
            base.Initialize();

            Source = new SpriteSourceNew(
            new List<Rectangle>
            {
                new Rectangle(183, 33, 18, 18)
            });
            Animation = new PeriodicFunction<int>();

        }
        public override void Load(ContentManager content)
        {

            Source.Load(content, "items");
        }

    }
}
