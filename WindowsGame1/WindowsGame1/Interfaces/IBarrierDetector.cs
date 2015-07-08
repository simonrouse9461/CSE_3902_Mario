using System;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public interface IBarrierDetector
    {
        Collection<Type> BarrierList { get; }
        Collection<Type> BarrierExceptionList { get; }
        void AddBarrier<T>(Type type = null) where T : IObject;
        void RemoveBarrier<T>(Type type = null) where T : IObject;
        void ClearBarrier();
        void Detect(); 
    }
}