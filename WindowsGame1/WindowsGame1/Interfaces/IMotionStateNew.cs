using Microsoft.Xna.Framework;

namespace MarioGame
{
    public interface IMotionStateNew
    {
        void  SetCore(ICoreNew c);
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        bool IsFrozen { get; }
        bool IsStatic { get; }

        void Freeze(int timer = 0);
        void Restore();
        void Adjust(Vector2 offset);
        void Reset();
        void ResetHorizontalVelocity();
        void ResetVerticalVelocity();
        void Update();
    }
}