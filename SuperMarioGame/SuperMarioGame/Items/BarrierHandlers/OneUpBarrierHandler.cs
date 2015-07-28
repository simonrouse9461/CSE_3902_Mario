using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class OneUpBarrierHandler : BarrierHandlerKernelNew<OneUpStateController>
    {

        public OneUpBarrierHandler(ICoreNew core) : base(core) { }

        public override void HandleCollision()
        {
            CheckFloor();
        }

        private void CheckFloor()
        {
            if (Core.StateController.MotionState.isGenerating) return;
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
