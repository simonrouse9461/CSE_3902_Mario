using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class KoopaBarrierHandler : BarrierHandlerKernel<KoopaStateController>
    {
        public KoopaBarrierHandler(ICore core) : base(core) { }

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

        public override void HandleOverlap()
        {
            if (BarrierCollision.AllEdge.None) return;

            while (DetectBarrier().Bottom.Touch)
            {
                Core.GeneralMotionState.Adjust(new Vector2(0, -1));
            }
        }

        public override void ResetVelocity()
        {
            Core.StateController.MotionState.LoseGravity();
        }
    }
}