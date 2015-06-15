﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class FacingLeftSmallMarioSprite : SpriteKernel
    {
        protected override void Initialize()
        {
            Source = new SpriteSourceNew(
                new List<Rectangle>
                {
                    new Rectangle(181, 0, 13, 16)
                });
        }

        public override void Load(ContentManager content)
        {
            Source.Load(content, "Mario");
        }
    }
}