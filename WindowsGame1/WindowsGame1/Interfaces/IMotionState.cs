using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotionState
    {
        Vector2 Position { get; set; }

        void Up1();

        void Down1();

        void Left1();

        void Right1();

        void Reset();

        void Update();
    }
}