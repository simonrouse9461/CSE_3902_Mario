using System;

namespace WindowsGame1
{
    public interface ICollisionDetectorNew
    {
        Collision Detect(Type type, Func<IObject, bool> filter = null, int offset = 1);
        Collision Detect<T>(Func<T, bool> filter = null, int offset = 1) where T : IObject; 
    }
}