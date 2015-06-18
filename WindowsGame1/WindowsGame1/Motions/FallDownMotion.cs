using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class FallDownMotion : MotionKernel
    {
        private static readonly Vector2 StartVelocity = new Vector2(0, 3);

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