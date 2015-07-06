using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class InertiaMotion : MotionKernel
    {
        private static float Acceleration = 0.1f;
        private static float MaxVelocity = 3;

        public override Vector2 Velocity
        {
            get { return new Vector2(InitialVelocity.X, 0); }
        }

        public void Left()
        {
            var velocity = InitialVelocity - new Vector2(Acceleration, 0);
            InitialVelocity = Math.Abs(velocity.X) >= MaxVelocity ? InitialVelocity : velocity;
        }

        public void Right()
        {
            var velocity = InitialVelocity + new Vector2(Acceleration, 0);
            InitialVelocity = Math.Abs(velocity.X) >= MaxVelocity ? InitialVelocity : velocity;
        }
    }
}