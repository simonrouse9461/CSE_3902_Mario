using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MoveLeftFastMotion : MotionKernel
    {
        private Vector2 StartVelocity = new Vector2(-4, 0);

        public override Vector2 Velocity
        {
            get
            {
                var velocity = StartVelocity;
                return velocity;
            }
        }
    }
}