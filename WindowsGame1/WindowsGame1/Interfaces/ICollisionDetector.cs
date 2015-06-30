using System;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public interface ICollisionDetector
    {
        Collision Detect(Collection<Type> types, Collection<Type> exceptionTypes, Func<IObject, bool> filter = null, int offset = 1);
        Collision Detect<T>(Func<T, bool> filter = null, int offset = 1) where T : IObject; 
    }
}