using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotionState
    {
        Vector2 Position { get; set; }
        void Adjust(Vector2 offset);
        void Reset();
        void Update();
    }
}