using System;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public abstract class CollisionHandlerKernelNew<TStateController> : AbstractCollisionHandlerKernel<TStateController>
        where TStateController : IStateControllerNew, new()
    {
        public CoreNew<TStateController> Core { get; set; }

        protected CollisionHandlerKernelNew(ICoreNew core) : base(core)
        {
            Core = (CoreNew<TStateController>)core;
        }
    }
}