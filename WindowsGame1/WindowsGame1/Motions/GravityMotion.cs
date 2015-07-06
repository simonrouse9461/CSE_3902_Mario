using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class GravityMotion : MotionKernel
    {
        public static Vector2 MaxVelocity
        {
            get { return new Vector2(0, 4.5f); }
        } 

        public override Vector2 Velocity
        {
            get
            {
                var velocity = MaxVelocity;
                return velocity;
            }
        }
    }
}