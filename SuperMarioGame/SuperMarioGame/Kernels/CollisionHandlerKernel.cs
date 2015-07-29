using System;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public abstract class CollisionHandlerKernel<TStateController> : AbstractCollisionHandlerKernel<TStateController>
        where TStateController : IStateController, new()
    {
        public Core<TStateController> Core { get; set; }

        protected CollisionHandlerKernel(ICore core) : base(core)
        {
            Core = (Core<TStateController>)core;
        }
    }
}