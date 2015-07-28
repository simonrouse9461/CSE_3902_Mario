using System;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public interface IBarrierHandler
    {
        bool IsBarrier { get; }
        bool NoBarrier { get; }
        Collision DetectBarrier(int offset = 0);
        void AddBarrier<T>(Type type = null) where T : IObject;
        void RemoveBarrier<T>(Type type = null) where T : IObject;
        void ClearBarrier();
        void BecomeBarrier();
        void BecomeNonBarrier();
        void Update();
        void ResetVelocity();
        void HandleCollision();
        void HandleOverlap();
    }
}