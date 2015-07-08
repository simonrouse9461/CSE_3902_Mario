using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotion
    {
        Vector2 Velocity { get; }
        bool Finish { get; }
        void Reset(Vector2 initialVelocity = default(Vector2));
        void ResetX(float speed = 0);
        void ResetY(float speed = 0);
        void Update(int phase = -1);
    }
}