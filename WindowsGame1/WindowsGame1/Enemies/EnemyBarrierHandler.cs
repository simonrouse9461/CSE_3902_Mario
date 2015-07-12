using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class GoombaBarrierHandler : BarrierHandlerKernel<GoombaStateController>
    {
        public GoombaBarrierHandler(ICore core) : base(core) { }

        public override void HandleCollision()
        {
            CheckFloor();
        }

        private void CheckFloor()
        {
            if (Core.StateController.MotionState.Gravity && BarrierCollision.Bottom.Touch)
            {
                Core.StateController.MotionState.ObtainGravity();
            }
            else if (Core.StateController.MotionState.Gravity && !BarrierCollision.Bottom.Touch)
            {
                Core.StateController.MotionState.LoseGravity();
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
    }
}