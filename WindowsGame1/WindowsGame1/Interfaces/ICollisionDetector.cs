using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface ICollisionDetector
    {
        CollisionSide Detect(int offset = 1, bool onlySolid = false);
    }
}