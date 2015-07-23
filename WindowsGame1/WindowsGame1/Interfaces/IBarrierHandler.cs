using System;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public interface IBarrierHandler
    {
        Collision BarrierCollision { get; }
        Collection<Type> BarrierList { get; }
        Collection<Type> BarrierExceptionList { get; }
        Collision DetectBarrier(int offset = 0);
        void AddBarrier<T>(Type type = null) where T : IObject;
        void RemoveBarrier<T>(Type type = null) where T : IObject;
        void ClearBarrier();
        void Update();
        void ResetVelocity();
        void HandleCollision();
        void HandleOverlap();
    }
}