using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class MushroomBarrierHandler : BarrierHandlerKernel<MushroomStateController>
    {
        public MushroomBarrierHandler(ICore core) : base(core) { }
        public override void HandleCollision()
        {
            CheckFloor();
        }

        private void CheckFloor()
        {
            if (Core.StateController.MotionState.IsGenerating) return;
            if (BarrierCollision.Bottom.Touch)
            {
                Core.StateController.MotionState.LoseGravity();
            }
            else
            {
                Core.StateController.MotionState.ObtainGravity();
            }
        }
    }
}
