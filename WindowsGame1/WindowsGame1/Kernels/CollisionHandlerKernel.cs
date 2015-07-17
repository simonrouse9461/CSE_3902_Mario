using System;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public abstract class CollisionHandlerKernel<TStateController> : ICollisionHandler
        where TStateController : IStateController, new()
    {
        public Core<TStateController> Core { get; set; }

        protected CollisionHandlerKernel(ICore core)
        {
            if (core is Core<TStateController>)
                Core = (Core<TStateController>)core;
            else
                Core = new Core<TStateController>(core.Object)
                {
                    StateController = (TStateController)core.GeneralStateController,
                    CollisionHandler = core.CollisionHandler,
                    CommandExecutor = core.CommandExecutor,
                    BarrierHandler = core.BarrierHandler
                };
        }

        public abstract void Handle();
    }
}