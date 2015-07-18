using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class StarBarrierHandler : BarrierHandlerKernel<StarStateController>
    {

        public StarBarrierHandler(ICore core) : base(core) { }

        public override void HandleCollision()
        {
            HitWall();
            HitFloor();
        }

        private void HitWall()
        {
            if (BarrierCollision.AnySide.Touch)
                Core.StateController.MotionState.ChangeDirection();
        }

        private void HitFloor()
        {
            if (BarrierCollision.Bottom.Touch)
                Core.StateController.Bouncing();
        }

    }
}
