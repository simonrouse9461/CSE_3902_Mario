﻿using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class GravityMotion : MotionKernel
    {
        public static Vector2 Max { get { return new Vector2(0, 5.4f); } }

        public GravityMotion()
        {
            Acceleration = new Vector2(0, 0.5f);
            MaxVelocity = Max;
        }
        
        public override Vector2 Velocity
        {
            get
            {
                var velocity = StartVelocity.Y + Circulator.Phase*Acceleration.Y;
                velocity = velocity < 0 ? velocity : MaxVelocity.Y;
                return new Vector2(0, velocity);
            }
        }

        public override void Reset()
        {
            StartVelocity = CurrentVelocity;
            Circulator.Reset();
        }
    }
}