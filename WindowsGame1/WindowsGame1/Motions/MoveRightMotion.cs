using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MoveRightMotion : MotionKernel
    {
        private static readonly Vector2 StartVelocity = new Vector2(2, 0);

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