using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotion
    {
        Vector2 Velocity { get; }
        bool Finish { get; }
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