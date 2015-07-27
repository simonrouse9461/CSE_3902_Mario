using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class Static : MotionKernel
    {
        public override bool Finish
        {
            get { return true; }
        }

        public override Vector2 GetVelocity(int phase)
        {
            return default(Vector2);
        }
    }
}