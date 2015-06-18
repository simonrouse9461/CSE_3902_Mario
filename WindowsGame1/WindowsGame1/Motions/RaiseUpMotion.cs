using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class RaiseUpMotion : MotionKernel
    {
        private static Vector2 StartVelocity = new Vector2(0, -3);

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