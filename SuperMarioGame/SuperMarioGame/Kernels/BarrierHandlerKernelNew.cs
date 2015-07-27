using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public abstract class BarrierHandlerKernelNew<TStateController> : AbstractBarrierHandlerKernel<TStateController>
        where TStateController : IStateControllerNew, new()
    {
        protected CoreNew<TStateController> Core { get; set; }

        protected BarrierHandlerKernelNew(ICoreNew core)
            : base(core)
        {
            Core = (CoreNew<TStateController>)core;
        }
    }
}