﻿using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class FallDownMotion : MotionKernel
    {
        private static Vector2 StartVelocity = new Vector2(0, 3);

        public override Vector2 GetVelocity()
        {
            var velocity = StartVelocity;
            return velocity;
        }
    }
}