using System;

namespace WindowsGame1
{
    public interface IBarrierDetector
    {
        void AddBarrier<T>(Type type = null) where T : IObject;
        void RemoveBarrier<T>(Type type = null) where T : IObject;
        void ClearBarrier();
        void Detect(); 
    }
}