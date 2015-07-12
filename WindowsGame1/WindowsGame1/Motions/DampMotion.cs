using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
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

        public override Vector2 Velocity
        {
            get
            {
                _sign = Math.Sign(InitialVelocity.X);
                var velocity = InitialVelocity.X - Circulator.Phase*Acceleration.X*_sign;
                return velocity*_sign <= 0 ? default(Vector2) : new Vector2(velocity, 0);
            }
        }
    }
}