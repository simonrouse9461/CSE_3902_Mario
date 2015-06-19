using System;

namespace WindowsGame1
{
    public interface ICollisionDetectorNew
    {
        CollisionSide Detect(Type type, Func<IObject, bool> condition = null, int offset = 1);
        CollisionSide Detect<T>(Func<T, bool> condition = null, int offset = 1) where T : IObject; 
    }
}