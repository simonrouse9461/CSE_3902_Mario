using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface ICollisionDetector
    {
        CollisionSideOld Detect(bool onlySolid = false, bool onlyActive = false, int offset = 1);
    }
}