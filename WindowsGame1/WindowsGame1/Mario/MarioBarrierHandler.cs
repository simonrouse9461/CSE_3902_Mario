using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioBarrierHandler : BarrierHandlerKernelNew<MarioStateController>
    {
        private bool WasOnFloor;

        public MarioBarrierHandler(ICoreNew core) : base(core) { }

        public override void HandleCollision()
        {
            CheckCeiling();
            CheckFloor();
        }

        public override void ResetVelocity()
        {
            if (BarrierCollision.Bottom.Touch && Core.Object.GoingDown) Core.GeneralMotionState.ResetVerticalVelocity();
            if ((BarrierCollision.TopLeft | BarrierCollision.TopRight).Cover && Core.Object.GoingUp) Core.GeneralMotionState.ResetVerticalVelocity();
            if (BarrierCollision.Left.Touch && Core.Object.GoingLeft) Core.GeneralMotionState.ResetHorizontalVelocity();
            if (BarrierCollision.Right.Touch && Core.Object.GoingRight) Core.GeneralMotionState.ResetHorizontalVelocity();
        }

        private void CheckCeiling()
        {
            if ((BarrierCollision.TopLeft | BarrierCollision.TopRight).Cover)
            {
                Core.StateController.Fall();
            }
        }

        private void CheckFloor()
        {
            if (BarrierCollision.Bottom.Touch && !Core.Object.GoingUp)
            {
                Core.StateController.KeepOnLand();
                WasOnFloor = true;
            }
            else
            {
                Core.StateController.Liftoff();
                WasOnFloor = false;
            }
        }

        public override void HandleOverlap()
        {
            Collision c;

            if (BarrierCollision.AllEdge.None) return;

            while (DetectBarrier().Bottom.Touch)
            {
                Core.GeneralMotionState.Adjust(new Vector2(0, -1));
            }
            for (c = DetectBarrier(); (c.TopLeft | c.TopRight).Cover; c = DetectBarrier())
            {
                Core.GeneralMotionState.Adjust(new Vector2(0, 1));
            }
            for (c = DetectBarrier();
                c.Left.Touch && Core.Object.GoingLeft;
                c = DetectBarrier())
            {
                Core.GeneralMotionState.Adjust(new Vector2(1, 0));
            }
            for (c = DetectBarrier();
                c.Right.Touch && Core.Object.GoingRight;
                c = DetectBarrier())
            {
                Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
            }
            c = DetectBarrier();
            if (c.TopRight.Touch && c.TopLeft.None ||
                c.Right.Touch && Core.Object.GoingUp)
                Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
            c = DetectBarrier();
            if (c.TopLeft.Touch && c.TopRight.None ||
                c.Left.Touch && Core.Object.GoingUp)
                Core.GeneralMotionState.Adjust(new Vector2(1, 0));
        }
    }
}