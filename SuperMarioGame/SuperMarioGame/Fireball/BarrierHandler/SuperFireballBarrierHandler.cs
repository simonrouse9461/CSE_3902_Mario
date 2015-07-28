using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class SuperFireballBarrierHandler : BarrierHandlerKernelNew<SuperFireballStateController>
    {

        public SuperFireballBarrierHandler(ICoreNew core) : base(core) { }

        public override void HandleCollision()
        {
            if (BarrierCollision.AnyEdge.Touch)
                Core.DelayCommand(Core.StateController.Explode);
        }
    }
}
