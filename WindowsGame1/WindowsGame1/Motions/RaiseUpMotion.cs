using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class RaiseUpMotion : MotionKernel
    {
        public RaiseUpMotion()
        {
            StartVelocity = new Vector2(0, -0.4f);
        }

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