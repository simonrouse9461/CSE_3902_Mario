using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class SuddenStopMotion : MotionKernel
    {
        private Vector2 Acceleration;
        private int Sign;

        public SuddenStopMotion(float acceleration)
        {
            Acceleration = new Vector2(acceleration, 0);
        }

        public override bool End()
        {
            return (int)GetVelocity().X == 0;
        }

        public override Vector2 GetVelocity()
        {
            Sign = Math.Sign(InitialVelocity.X);
            var velocity = InitialVelocity - Circulator.Phase*Acceleration*Sign;
            return velocity.X*Sign <= 0 ? default(Vector2) : velocity;
        }
    }
}