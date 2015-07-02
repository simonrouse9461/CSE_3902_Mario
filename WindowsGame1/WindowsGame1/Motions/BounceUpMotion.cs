using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BounceUpMotion : MotionKernel
    {
        private Vector2 StartVelocity;
        private Vector2 Acceleration;
        private Vector2 MaxVelocity;

        public override Vector2 Velocity
        {
            get
            {
                var velocity = Circulator.Phase*Acceleration + StartVelocity;
                velocity = (velocity.Y < MaxVelocity.Y) ? velocity : MaxVelocity;
                return velocity;
            }
        }

        public BounceUpMotion MarioDie
        {
            get
            {
                StartVelocity = new Vector2(0, -3);
                Acceleration = new Vector2(0, 0.1f);
                MaxVelocity = new Vector2(0, 6);
                return this;
            }
        }
    }
}