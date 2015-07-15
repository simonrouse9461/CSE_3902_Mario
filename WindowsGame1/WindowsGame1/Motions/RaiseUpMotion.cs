﻿using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class RaiseUpMotion : MotionKernel
    {
        public RaiseUpMotion()
        {
            StartVelocity = new Vector2(0, -0.5f);
        }

        public override Vector2 Velocity
        {
            get
            {
                var velocity = StartVelocity;
                return velocity;
            }
        }
    }
}