using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class GravityMotion : MotionKernel
    {
        public static Vector2 Max { get { return new Vector2(0, 7.5f); } }

        public GravityMotion()
        {
            Acceleration = new Vector2(0, 0.5f);
            MaxVelocity = Max;
        }

        public override Vector2 GetVelocity(int phase)
        {
            var velocity = StartVelocity.Y + phase*Acceleration.Y;
            velocity = velocity < 0 ? velocity : MaxVelocity.Y;
            return new Vector2(0, velocity);
        }

        public override void Reset()
        {
            StartVelocity = CurrentVelocity;
            Circulator.Reset();
        }
    }
}