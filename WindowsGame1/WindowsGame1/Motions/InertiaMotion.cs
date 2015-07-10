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
            get { return new Vector2(CurrentVelocity.X, 0); }
        }

        public void Left()
        {
            var velocity = CurrentVelocity - new Vector2(Acceleration, 0);
            SetCurrentVelocity(velocity.X <= -MaxVelocity ? CurrentVelocity : velocity);
        }

        public void Right()
        {
            var velocity = CurrentVelocity + new Vector2(Acceleration, 0);
            SetCurrentVelocity(velocity.X >= MaxVelocity ? CurrentVelocity : velocity);
        }
    }
}