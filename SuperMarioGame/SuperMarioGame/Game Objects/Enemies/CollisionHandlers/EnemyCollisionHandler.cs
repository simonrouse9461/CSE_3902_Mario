using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class EnemyCollisionHandler : AbstractCollisionHandlerKernel<IEnemyStateController>
    {
        public EnemyCollisionHandler(ICore core) : base(core) { }

        public override void Handle()
        {
            HandleStarPower();
            HandleMario();
            HandleKoopa();
            HandleBlock();
            HandleBlockDebris();
            HandleFireball();
        }

        public virtual void HandleStarPower()
        {
            if (AbstractCore.CollisionDetector.Detect<Mario>(mario => mario.StarPower).AnyEdge.Touch)
            {
                AbstractStateController.Flip();
            }
        }

        public virtual void HandleMario()
        {
            if (AbstractCore.CollisionDetector.Detect<Mario>(mario => (mario.Alive && mario.GoingDown)).Top.Touch)
            {
                AbstractStateController.MarioSmash();
            }
        }

        public virtual void HandleKoopa()
        {
            if (AbstractCore.CollisionDetector.Detect<Koopa>(koopa => koopa.IsMovingShell).AnySide.Touch)
            {
                AbstractStateController.Flip();
            }
        }

        public virtual void HandleBlock()
        {
            if (AbstractCore.CollisionDetector.Detect<IBlock>(block => block.Hit).Bottom.Touch)
            {
                AbstractStateController.Flip();
            }
        }

        public virtual void HandleBlockDebris()
        {
            if (AbstractCore.CollisionDetector.Detect<BlockDebris>().AnyEdge.Touch)
            {
                AbstractStateController.Flip();
            }
        }

        public virtual void HandleFireball()
        {
            if (AbstractCore.CollisionDetector.Detect<IFireball>().AnyEdge.Touch)
            {
                AbstractStateController.Flip();
            }
        }
    }
}