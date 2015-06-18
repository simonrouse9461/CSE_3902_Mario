using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class AccelerateLeftMotion : MotionKernel
    {
        private readonly Vector2 Acceleration;

        private readonly Vector2 MaxVelocity;

        public AccelerateLeftMotion(float acceleration, float max)
        {
            Acceleration = new Vector2(-acceleration, 0);
            MaxVelocity = new Vector2(-max, 0);
        }

        public override Vector2 Velocity
        {
            get
            {
                var velocity = Circulator.Phase*Acceleration + InitialVelocity;
                return velocity.X <= MaxVelocity.X ? MaxVelocity : velocity;
            }
        }
    }
}