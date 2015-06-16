﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Coin : ObjectKernel<CoinSpriteState, BlankMotionState>
    {
        public  Coin(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new CoinSpriteState();
            MotionState = new BlankMotionState(location);
        }
    }
}