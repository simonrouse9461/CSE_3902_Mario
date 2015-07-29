using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public abstract class BarrierHandlerKernel<TStateController> : AbstractBarrierHandlerKernel<TStateController>
        where TStateController : IStateController, new()
    {
        protected Core<TStateController> Core { get; set; }

        protected BarrierHandlerKernel(ICore core)
            : base(core)
        {
            Core = (Core<TStateController>)core;
        }
    }
}