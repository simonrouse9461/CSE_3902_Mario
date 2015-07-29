using System;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public abstract class AbstractCollisionHandlerKernel<TStateController> : ICollisionHandler
        where TStateController : IStateController
    {
        protected ICore AbstractCore { get; set; }

        protected TStateController AbstractStateController
        {
            get { return (TStateController) AbstractCore.GeneralStateController; }
        }

        protected AbstractCollisionHandlerKernel(ICore core)
        {
            AbstractCore = core;
        }

        public abstract void Handle();
    }
}