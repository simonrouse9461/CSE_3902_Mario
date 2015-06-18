using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface ICollisionHandler
    {
        void Handle();
        void AddBarrier<T>() where T : IObject;
        void RemoveBarrier<T>() where T : IObject;
        void DetectBarrier();
    }
}