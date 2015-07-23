using Microsoft.Xna.Framework;

namespace MarioGame
{
    public interface IMotionState
    {
        void  SetCore(ICoreNew c);
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        bool isFrozen { get; }
        bool isStatic { get; }

        StatusSwitch<IMotion> FindMotion<T>(T motion = null) where T : class, IMotion, new();
        void Freeze(int timer = 0);
        void Restore();
        void Adjust(Vector2 offset);
        void Reset();
        void ResetHorizontalVelocity();
        void ResetVerticalVelocity();
        void Update();
    }
}