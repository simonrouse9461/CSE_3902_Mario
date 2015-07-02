using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MoveLeftMotion : MotionKernel
    {
        private Vector2 StartVelocity;

        public override Vector2 Velocity
        {
            get
            {
                var velocity = StartVelocity;
                return velocity;
            }
        }

        public MoveLeftMotion EnemyVelocity
        {
            get
            {
                StartVelocity = new Vector2(-2, 0);
                return this;
            }
        }

        public MoveLeftMotion ItemVelocity
        {
            get
            {
                StartVelocity = new Vector2(-2, 0);
                return this;
            }
        }

        public MoveLeftMotion FireballVelocity
        {
            get
            {
                StartVelocity = new Vector2(-6, 0);
                return this;
            }
        }
    }
}