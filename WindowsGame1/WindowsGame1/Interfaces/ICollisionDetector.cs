using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface ICollisionDetector
    {
        CollisionSide Detect();
    }
}