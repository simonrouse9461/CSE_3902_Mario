using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class GoombaCollisionHandler : CollisionHandlerKernelNew<GoombaStateController>
    {
        public GoombaCollisionHandler(ICore core) : base(core){}

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
                else
                {
                    Collection<Type> BarrierList = new Collection<Type>();
                    BarrierList.Add(typeof(IBlock));
                    BarrierList.Add(typeof(GreenPipeObject));

                    if (Core.CollisionDetector.Detect(BarrierList).AnySide.Touch) {
                        Core.StateController.Turn();
                    }
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