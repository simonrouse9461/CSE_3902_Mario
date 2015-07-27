using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class GoombaCollisionHandler : CollisionHandlerKernelNew<GoombaStateController>
    {
        public GoombaCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            HandleMario();
            HandleKoopa();
            HandleBlock();
            HandleBlockDebris();
            HandleFireball();
        }

        private void HandleMario()
        {
            if (Core.CollisionDetector.Detect<MarioObject>(mario => mario.StarPower).AnyEdge.Touch)
            {
                Core.StateController.Flip();
            }
            if (Core.CollisionDetector.Detect<MarioObject>(mario => (mario.Alive && mario.GoingDown)).Top.Touch)
            {
                Core.StateController.MarioSmash();
            }
        }

        private void HandleKoopa()
        {
            if (Core.CollisionDetector.Detect<Koopa>(koopa => koopa.IsMovingShell).AnySide.Touch)
            {
                Core.StateController.Flip();
            }
        }

        private void HandleBlock()
        {
            if (Core.CollisionDetector.Detect<IBlock>(block => block.Hit).Bottom.Touch)
            {
                Core.StateController.Flip();
            }
        }

        private void HandleBlockDebris()
        {
            if (Core.CollisionDetector.Detect<BlockDebris>().AnyEdge.Touch)
            {
                Core.StateController.Flip();
            }
        }

        private void HandleFireball()
        {
            if (Core.CollisionDetector.Detect<IFireball>().AnyEdge.Touch)
            {
                Core.StateController.Flip();
            }
        }
    }
}