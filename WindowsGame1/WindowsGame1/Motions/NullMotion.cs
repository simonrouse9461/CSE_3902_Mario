using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NullMotion : MotionKernel
    {
        public override bool Finish
        {
            get { return true; }
        }

        public override Vector2 Velocity
        {
            get { return default(Vector2); }
        }
    }
}