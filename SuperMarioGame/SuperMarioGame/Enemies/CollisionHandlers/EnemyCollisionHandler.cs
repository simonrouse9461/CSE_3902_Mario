using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class EnemyCollisionHandler : AbstractCollisionHandlerKernel<IEnemyStateController>
    {
        public EnemyCollisionHandler(ICoreNew core) : base(core) { }

        public override void Handle()
        {
            HandleMario();
            HandleKoopa();
            HandleBlock();
            HandleBlockDebris();
            HandleFireball();
        }

        protected virtual void HandleMario()
        {
            if (AbstractCore.CollisionDetector.Detect<MarioObject>(mario => mario.StarPower).AnyEdge.Touch)
            {
                AbstractStateController.Flip();
            }
            if (AbstractCore.CollisionDetector.Detect<MarioObject>(mario => (mario.Alive && mario.GoingDown)).Top.Touch)
            {
                AbstractStateController.MarioSmash();
            }
        }

        protected virtual void HandleKoopa()
        {
            if (AbstractCore.CollisionDetector.Detect<Koopa>(koopa => koopa.IsMovingShell).AnySide.Touch)
            {
                AbstractStateController.Flip();
            }
        }

        protected virtual void HandleBlock()
        {
            if (AbstractCore.CollisionDetector.Detect<IBlock>(block => block.Hit).Bottom.Touch)
            {
                AbstractStateController.Flip();
            }
        }

        protected virtual void HandleBlockDebris()
        {
            if (AbstractCore.CollisionDetector.Detect<BlockDebris>().AnyEdge.Touch)
            {
                AbstractStateController.Flip();
            }
        }

        protected virtual void HandleFireball()
        {
            if (AbstractCore.CollisionDetector.Detect<IFireball>().AnyEdge.Touch)
            {
                AbstractStateController.Flip();
            }
        }
    }
}