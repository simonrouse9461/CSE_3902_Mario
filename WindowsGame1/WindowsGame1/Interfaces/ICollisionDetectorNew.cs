using System;

namespace WindowsGame1
{
    public interface ICollisionDetectorNew
    {
        CollisionSideNew Detect(Type type, Func<IObject, bool> condition = null, int offset = 1);
        CollisionSideNew Detect<T>(Func<T, bool> condition = null, int offset = 1) where T : IObject; 
    }
}