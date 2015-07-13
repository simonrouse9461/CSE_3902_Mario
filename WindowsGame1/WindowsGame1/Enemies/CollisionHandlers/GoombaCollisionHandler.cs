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
            if (!Core.StateController.SpriteState.Dead)
            {
                if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.StarPower).AnyEdge.Touch)
                {
                    Core.StateController.MarioSmash();
                }
                if (Core.CollisionDetector.Detect<MarioObject>(mario => (mario.Alive && mario.GoingDown)).Top.Touch)
                {
                    Core.StateController.MarioSmash();
                }
                else if (Core.CollisionDetector.Detect<FireballObject>().AnyEdge.Touch || Core.CollisionDetector.Detect<Koopa>(koopa => koopa.isMovingShell).AnySide.Touch)
                {
                    Core.StateController.MarioSmash();
                }
                else
                {
                    if (Core.CollisionDetector.Detect<IObject>(obj => obj.Solid).AnySide.Touch)
                    {
                        Core.StateController.Turn();
                    }
                }
            }
        }
    }
}