using System;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioBarrierHandler : BarrierHandlerKernelNew<MarioStateController>
    {
        public MarioBarrierHandler(ICoreNew core) : base(core) { }

        public override void HandleCollision()
        {
            CheckCeiling();
            CheckFloor();
        }

        public override void ResetVelocity()
        {
            if (BarrierCollision.Bottom.Touch && Core.Obj.GoingDown) Core.GeneralMotionState.ResetVerticalVelocity();
            if ((BarrierCollision.TopLeft | BarrierCollision.TopRight).Cover && Core.Obj.GoingUp) Core.GeneralMotionState.ResetVerticalVelocity();
            if (BarrierCollision.Left.Touch && Core.Obj.GoingLeft) Core.GeneralMotionState.ResetHorizontalVelocity();
            if (BarrierCollision.Right.Touch && Core.Obj.GoingRight) Core.GeneralMotionState.ResetHorizontalVelocity();
        }

        protected virtual void CheckCeiling()
        {
            if ((BarrierCollision.TopLeft | BarrierCollision.TopRight).Cover)
            {
                Core.StateController.Fall();
                SoundManager.BumpSoundPlay();
            }
        }

        protected virtual void CheckFloor()
        {
            if (BarrierCollision.Bottom.Touch)
            {
                if (!Core.Obj.GoingUp) 
                    Core.StateController.KeepOnLand();
            }
            else Core.StateController.Liftoff();
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
                c.Left.Touch && Core.Obj.GoingLeft;
                c = DetectBarrier())
            {
                Core.GeneralMotionState.Adjust(new Vector2(1, 0));
            }
            for (c = DetectBarrier();
                c.Right.Touch && Core.Obj.GoingRight;
                c = DetectBarrier())
            {
                Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
            }
            c = DetectBarrier();
            if (c.TopRight.Touch && c.TopLeft.None ||
                c.Right.Touch && Core.Obj.GoingUp)
                Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
            c = DetectBarrier();
            if (c.TopLeft.Touch && c.TopRight.None ||
                c.Left.Touch && Core.Obj.GoingUp)
                Core.GeneralMotionState.Adjust(new Vector2(1, 0));
        }
    }
}