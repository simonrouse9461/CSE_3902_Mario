using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class GoombaBarrierHandler : BarrierHandlerKernelNew<GoombaStateController>
    {
        public GoombaBarrierHandler(ICoreNew core) : base(core) { }

        public override void HandleCollision()
        {
            CheckFloor();
        }

        private void CheckFloor()
        {
            if (Core.StateController.MotionState.Gravity && BarrierCollision.Bottom.Touch)
            {
                Core.StateController.MotionState.LoseGravity();
            }
            else if (!Core.StateController.MotionState.Gravity && !BarrierCollision.Bottom.Touch)
            {
                Core.StateController.MotionState.ObtainGravity();
            }
        }

        public override void ResetVelocity()
        {
            Core.StateController.MotionState.LoseGravity();
        }
    }
}