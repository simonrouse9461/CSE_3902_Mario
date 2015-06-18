using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class SuddenStopMotion : MotionKernel
    {
        private readonly Vector2 Acceleration;
        private int Sign;

        public SuddenStopMotion(float acceleration)
        {
            Acceleration = new Vector2(acceleration, 0);
        }

        public override bool Finish
        {
            get { return (int) Velocity.X == 0; }
        }

        public override Vector2 Velocity
        {
            get
            {
                Sign = Math.Sign(InitialVelocity.X);
                var velocity = InitialVelocity - Circulator.Phase*Acceleration*Sign;
                return velocity.X*Sign <= 0 ? default(Vector2) : velocity;
            }
        }
    }
}