using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MoveRightMotion : MotionKernel
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

        public MoveRightMotion EnemyVelocity
        {
            get
            {
                StartVelocity = new Vector2(2, 0);
                return this;
            }
        }

        public MoveRightMotion ItemVelocity
        {
            get
            {
                StartVelocity = new Vector2(2, 0);
                return this;
            }
        }

        public MoveRightMotion FireballVelocity
        {
            get
            {
                StartVelocity = new Vector2(6, 0);
                return this;
            }
        }
    }
}