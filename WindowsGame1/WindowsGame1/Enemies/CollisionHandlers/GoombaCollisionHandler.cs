using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class GoombaCollisionHandler : CollisionHandlerKernel<GoombaStateController>
    {
        public GoombaCollisionHandler(ICore core) : base(core){}

        public override void Handle()
        {
            Core.BarrierHandler.RemoveBarrier<IItem>();
            if (!Core.StateController.SpriteState.Dead)
            {
                if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.StarPower).AnySide.Touch || Core.CollisionDetector.Detect<Koopa>(koopa => koopa.isMovingShell).AnySide.Touch)
                {
                    Core.StateController.Flip();
                }
                else if (Core.CollisionDetector.Detect<MarioObject>(mario => (mario.Alive && mario.GoingDown)).Top.Touch)
                {
                    Core.StateController.MarioSmash();
                }
                else if (Core.CollisionDetector.Detect<FireballObject>().AnyEdge.Touch)
                {
                    Core.StateController.MarioSmash();
                }
                else if(Core.CollisionDetector.Detect<IBlock>(block => block.Hit).Bottom.Touch)
                {
                    Core.StateController.Flip();
                }
                else
                {
                    if (!Core.StateController.MotionState.Gravity && Core.CollisionDetector.Detect<IObject>(obj => obj.Solid).AnySide.Touch)
                    {
                        Core.StateController.Turn();
                    }
                }
            }
        }
    }
}