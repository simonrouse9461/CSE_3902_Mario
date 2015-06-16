using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class FallDownMotion : MotionKernel
    {
        private static Vector2 StartVelocity = new Vector2(0, -3);
        private static Vector2 Acceleration = new Vector2(0, 0.1f);

        public override bool End()
        {
            return false;
        }

        public override Vector2 GetVelocity()
        {
            var velocity = Circulator.Phase * Acceleration + StartVelocity;
            return velocity;
        }
    }
}