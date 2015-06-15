﻿using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NullMotion : MotionKernel
    {
        public override bool End()
        {
            return false;
        }

        public override Vector2 GetVelocity()
        {
            return default(Vector2);
        }
    }
}