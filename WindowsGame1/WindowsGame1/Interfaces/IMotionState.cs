using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotionState
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        bool Frozen { get; }
        bool Static { get; }

        StatusSwitch<IMotion> FindMotion<T>(T motion = null) where T : class, IMotion, new();
        void Freeze();
        void Restore();
        void Adjust(Vector2 offset);
        void Reset();
        void ResetHorizontalVelocity();
        void ResetVerticalVelocity();
        void Update();
    }
}