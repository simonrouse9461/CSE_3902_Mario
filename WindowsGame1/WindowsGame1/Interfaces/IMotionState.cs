using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotionState
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        void Adjust(Vector2 offset);
        void Reset();
        void ResetHorizontalVelocity();
        void ResetVerticalVelocity();
        void Update();
    }
}