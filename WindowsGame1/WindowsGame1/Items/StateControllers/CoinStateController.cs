﻿using System;

namespace MarioGame
{
    public class CoinStateController : StateControllerKernel<CoinSpriteState, CoinMotionState>
    {

        public void Generated()
        {
            MotionState.Generated();
        }

        public override void Update()
        {
            if (MotionState.StopMoving)
            {
                Core.Object.Unload();
            }
        }

        public void Static()
        {
            MotionState.ResetStatus();
        }
    }
}