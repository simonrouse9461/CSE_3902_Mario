using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface ICollisionHandlerNew
    {
        void Handle();
        void AddBarrier<T>(Type type = null) where T : IObject;
        void RemoveBarrier<T>(Type type = null) where T : IObject;
        void DetectBarrier();
    }
}