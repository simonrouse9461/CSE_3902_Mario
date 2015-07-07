using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class GoombaCollisionHandler : CollisionHandlerKernelNew<GoombaStateController>
    {
        public GoombaCollisionHandler(ICore core) : base(core){}

        public override void Handle()
        {
            if (Core.StateController.MotionState.isAlive()) {
                if (Core.CollisionDetector.Detect<MarioObject>(mario => (mario.Alive && mario.GoingDown) || mario.StarPower).Top.Touch)
                {
                    Core.StateController.MarioSmash();
                }
                else if (Core.CollisionDetector.Detect<FireballObject>().AnyEdge.Touch || Core.CollisionDetector.Detect<Koopa>(koopa => koopa.isMovingShell).AnySide.Touch)
                {
                    Core.StateController.MarioSmash();
                }
                else if (Core.CollisionDetector.Detect<IBlock>().AnySide.Touch || Core.CollisionDetector.Detect<GreenPipeObject>().AnySide.Touch)
                {
                    Core.StateController.Turn();
                }
                
            }



            /*
             *  if (Detector.Detect<MarioObject>(mario => mario.Alive).AnySide.Touch)
            {
                if (Detector.Detect<MarioObject>(mario => mario.Alive).Left.Touch)
                {
                    Core.MotionState.TakeMarioHitFromSide("left");
                }
                else
                {
                    Core.MotionState.TakeMarioHitFromSide("right");
                }
            }
             */
        }
    }
}