using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class SuperFireballBarrierHandler : BarrierHandlerKernel<SuperFireballStateController>
    {

        public SuperFireballBarrierHandler(ICore core) : base(core) { }

        public override void HandleCollision()
        {
            if (BarrierCollision.AnyEdge.Touch)
                Core.DelayCommand(Core.StateController.Explode);
        }
    }
}
