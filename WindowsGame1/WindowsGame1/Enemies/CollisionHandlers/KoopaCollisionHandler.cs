using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class KoopaCollisionHandler : CollisionHandlerKernel<KoopaStateController>
    {
        public KoopaCollisionHandler(ICore core) : base(core){}

        public override void Handle()
        {
            if (Core.CollisionDetector.Detect<IObject>(obj => obj.Solid && !(obj is IEnemy)).AnySide.Touch)
            {
                Core.StateController.Turn();
            }

            if (!Core.StateController.SpriteState.Dead)
            {
                if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.StarPower).AnyEdge.Touch)
                {
                    Core.StateController.MarioSmash();
                }
                else if (Core.CollisionDetector.Detect<MarioObject>(mario => (mario.Alive && mario.GoingDown)).Top.Touch)
                {
                    Core.StateController.MarioSmash();
                }
                else if (Core.CollisionDetector.Detect<FireballObject>().AnyEdge.Touch || Core.CollisionDetector.Detect<Koopa>(koopa => koopa.isMovingShell).AnySide.Touch)
                {
                    Core.StateController.MarioSmash();
                }
            }
            else
            {
                Collision c = Core.CollisionDetector.Detect<MarioObject>(mario => mario.Alive);
                if (c.Left.Touch)
                {
                    Core.StateController.TakeMarioHitFromSide("left");
                }
                else if (c.Right.Touch)
                {
                    Core.StateController.TakeMarioHitFromSide("right");
                }
            }
        }
    }
}