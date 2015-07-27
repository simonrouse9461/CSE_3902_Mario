using System;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public abstract class CollisionHandlerKernelNew<TStateController> : ICollisionHandler
        where TStateController : IStateControllerNew, new()
    {
        public CoreNew<TStateController> Core { get; set; }

        protected CollisionHandlerKernelNew(ICoreNew core)
        {
            Core = (CoreNew<TStateController>)core;
        }

        public abstract void Handle();
    }
}