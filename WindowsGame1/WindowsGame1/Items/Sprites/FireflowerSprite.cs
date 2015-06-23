﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public class FireflowerSprite : SpriteKernelNew
    {
        public FireflowerSprite()
        {
            const int period = 4;

            ImageFile.Default = "items";
            Source.Default = new SpriteSourceNew
            {
                Coodinates = new Collection<Rectangle>
                {
                    new Rectangle(3, 64, 17, 18),
                    new Rectangle(33, 64, 17, 18),
                    new Rectangle(63, 64, 17, 18),
                    new Rectangle(93, 64, 17, 18)
                }
            };
            Animation.Default = new PeriodicFunction<int>(
                phase =>
                {
                    int[] frameSequence = { 0, 1, 2, 3 };
                    return frameSequence[phase];
                },
                period);
        }
    }
}
