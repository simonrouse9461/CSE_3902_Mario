using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class GravityMotion : MotionKernel
    {
        private float StartVelocity { get; set; }
        private float Acceleration { get { return 0.38f; } }

        public static Vector2 MaxVelocity
        {
            get { return new Vector2(0, 4.5f); }
        } 

        public override Vector2 Velocity
        {
            get
            {
                var velocity = StartVelocity + Circulator.Phase*Acceleration;
                velocity = velocity < 0 ? velocity : MaxVelocity.Y;
                return new Vector2(0, velocity);
            }
        }

        public override void Reset()
        {
            StartVelocity = CurrentVelocity.Y;
            Circulator.Reset();
        }
    }
}