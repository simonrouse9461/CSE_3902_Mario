using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class AccelerateRightMotion : MotionKernel
    {
        private Vector2 Acceleration;

        private Vector2 MaxVelocity;

        public AccelerateRightMotion(float acceleration, float max)
        {
            Acceleration = new Vector2(acceleration, 0);
            MaxVelocity = new Vector2(max, 0);
        }

        public override bool End()
        {
            return false;
        }

        public override Vector2 GetVelocity()
        {
            var velocity = Circulator.Phase*Acceleration + InitialVelocity;
            return velocity.X >= MaxVelocity.X ? MaxVelocity : velocity;
        }
    }
}