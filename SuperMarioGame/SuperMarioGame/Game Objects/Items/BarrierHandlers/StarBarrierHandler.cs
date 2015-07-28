using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class StarBarrierHandler : BarrierHandlerKernelNew<StarStateController>
    {

        public StarBarrierHandler(ICoreNew core) : base(core) { }

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
