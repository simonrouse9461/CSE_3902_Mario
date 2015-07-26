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
            HandleWall();
        }

        protected virtual void HandleWall()
        {
            if (BarrierCollision.AnySide.Touch)
            {
                Core.StateController.Explode();
            }
        }
    }
}
