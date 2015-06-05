using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotionState
    {
        Vector2 CurrentLocation();
        void Reset(Vector2 location, int frequency = 10);
        void Update();
    }
}