using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotionState
    {
        Vector2 Position { get; set; }
        void Reset();
        void Update();
    }
}