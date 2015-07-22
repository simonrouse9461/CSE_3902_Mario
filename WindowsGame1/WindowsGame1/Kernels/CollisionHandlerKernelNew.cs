using System;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public abstract class CollisionHandlerKernelNew<TStateController> : ICollisionHandler
        where TStateController : IStateControllerNew, new()
    {
        public CoreNew<TStateController> Core { get; set; }

        protected CollisionHandlerKernelNew(ICoreNew core)
        {
            if (core is CoreNew<TStateController>)
                Core = (CoreNew<TStateController>)core;
            else
                Core = new CoreNew<TStateController>(core.Object)
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