using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BlockMotion : MotionKernel
    {

        private static Vector2 StartVelocity = new Vector2(0, -3);
        private static Vector2 Acceleration = new Vector2(0, 1);

        public override Vector2 Velocity
        {
            get
            {
                var velocity = Circulator.Phase * Acceleration + StartVelocity;
                return velocity;
            }
        }
    }
}
