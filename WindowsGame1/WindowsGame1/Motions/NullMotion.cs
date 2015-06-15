using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NullMotion : MotionKernel
    {
        public override Vector2 GetVelocity()
        {
            return default(Vector2);
        }
    }
}