using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class KoopaCollisionHandler : CollisionHandlerKernelNew<KoopaStateController>
    {
        public KoopaCollisionHandler(ICore core) : base(core){}

        public override void Handle()
        {
            if (!Core.StateController.SpriteState.Dead) {
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
            else
            {
                Collision collis = Core.CollisionDetector.Detect<MarioObject>(mario => mario.Alive);
                if (collis.Left.Touch)
                {
                    Core.StateController.MotionState.TakeMarioHitFromSide("left");
                }
                else if (collis.Right.Touch)
                {
                    Core.StateController.MotionState.TakeMarioHitFromSide("right");
                }
                else if (Core.CollisionDetector.Detect<IBlock>().AnySide.Touch || Core.CollisionDetector.Detect<GreenPipeObject>().AnySide.Touch)
                {
                    Core.StateController.Turn();
                }
            }



            /*
             *  if (Detector.Detect<MarioObject>(mario => mario.Alive).AnySide.Touch)
            {
                
            }
             */
        }
    }
}