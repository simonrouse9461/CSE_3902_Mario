using Microsoft.Xna.Framework;

namespace SuperMario
{
    public interface IMotionState
    {
        void  SetCore(ICore c);
        Vector2 Position { get; }
        Vector2 LastSetPosition { get; set; }
        Vector2 Velocity { get; set; }
        bool IsFrozen { get; }
        bool IsStatic { get; }

        void Freeze(int timer = 0);
        void Restore();
        void SetPosition(Vector2 position);
        void AdjustPosition(Vector2 offset);
        void Reset();
        void ResetHorizontalVelocity();
        void ResetVerticalVelocity();
        void Update();
    }
}