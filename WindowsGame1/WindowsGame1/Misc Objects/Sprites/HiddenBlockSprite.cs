﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
namespace WindowsGame1
{
    public class HiddenBlockSprite : SpriteKernel
    {

        protected override void Initialize()
        {
            Source = new SpriteSource(
                new List<Rectangle>
                {
                    new Rectangle(16, 32, 16, 16)
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "blocks");
        }
    }
}
