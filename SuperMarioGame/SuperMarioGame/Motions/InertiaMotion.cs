using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class InertiaMotion : MotionKernel
    {
        public InertiaMotion()
        {
            Acceleration = new Vector2(0.1f, 0);
            MaxVelocity = new Vector2(3, 0);
        }

        public override Vector2 GetVelocity(int phase)
        {
            return new Vector2(CurrentVelocity.X, 0);
        }

        public void LeftAdjust()
        {
            var velocity = CurrentVelocity - Acceleration;
            SetCurrentVelocity(velocity.X <= -MaxVelocity.X ? CurrentVelocity : velocity);
        }

        public void RightAdjust()
        {
            var velocity = CurrentVelocity + Acceleration;
            SetCurrentVelocity(velocity.X >= MaxVelocity.X ? CurrentVelocity : velocity);
        }
    }
}