using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DampMotion : MotionKernel
    {
        private readonly float Acceleration = 0.15f;
        private int Sign;

        public override bool Finish
        {
            get { return Math.Abs(Velocity.X) < 0.001; }
        }

        public override Vector2 Velocity
        {
            get
            {
                Sign = Math.Sign(InitialVelocity.X);
                var velocity = InitialVelocity.X - Circulator.Phase*Acceleration*Sign;
                return velocity*Sign <= 0 ? default(Vector2) : new Vector2(velocity, 0);
            }
        }
    }
}