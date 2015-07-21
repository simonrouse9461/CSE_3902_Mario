using System;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public interface ICollisionDetector
    {
        Collision Detect(Collection<Type> types, Collection<Type> exceptionTypes, Func<IObject, bool> propertyFilter = null, int offset = 1);
        Collision Detect<T>(Func<T, bool> filter = null, int offset = 1) where T : IObject; 
    }
}