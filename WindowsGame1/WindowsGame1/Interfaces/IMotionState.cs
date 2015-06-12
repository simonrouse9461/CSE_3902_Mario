using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotionState
    {
        void Reset();
        void Update();
        void SetPosition(Vector2 position);
        Vector2 CurrentPosition();
    }
}