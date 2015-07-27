using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class DampMotion : MotionKernel
    {
        private int _sign;

        public DampMotion()
        {
            Acceleration = new Vector2(0.15f, 0);
        }

        public override bool Finish
        {
            get { return Math.Abs(Velocity.X) < 0.001; }
        }

        public override Vector2 GetVelocity(int phase)
        {
            _sign = Math.Sign(InitialVelocity.X);
            var velocity = InitialVelocity.X - phase*Acceleration.X*_sign;
            return velocity*_sign <= 0 ? default(Vector2) : new Vector2(velocity, 0);
        }
    }
}