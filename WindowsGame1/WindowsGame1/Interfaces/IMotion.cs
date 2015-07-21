using Microsoft.Xna.Framework;

namespace MarioGame
{
    public interface IMotion
    {
        Vector2 StartVelocity { get; }
        Vector2 MaxVelocity { get; }
        Vector2 Acceleration { get; }
        Vector2 Velocity { get; }
        bool Status { get; }
        bool Finish { get; }
        bool ReachMax { get; }
        int VersionCode { get; }

        bool SameVersion(IMotion motion);
        void SetInitialVelocity(Vector2 velocity = default(Vector2));
        void SetCurrentVelocity(Vector2 velocity = default(Vector2));
        void Reset(Vector2 velocity);
        void Reset();
        void ResetX(float speed = 0);
        void ResetY(float speed = 0);
        void Update(int phase = -1);
    }
}