using System;

namespace SuperMario
{
    public class MarioCollisionHandler : CollisionHandlerKernelNew<MarioStateController>
    {
        public MarioCollisionHandler(ICoreNew core) : base(core){}

        public override void Handle()
        {
            if (Core.StateController.SpriteState.Dead) return;

            HandleFireflower();
            HandleMushroom();
            HandleStar();
            HandleEnemy();
            HandleFlagPole();
            HandleOneUp();
            HandlePipe();
        }

        protected virtual void HandleMushroom()
        {
            if (Core.CollisionDetector.Detect<Mushroom>().AnyEdge.Touch)
            {
                Core.DelayCommand(Core.StateController.Grow, 5);
                SoundManager.PowerUpSoundPlay();
            }
        }

        protected virtual void HandleOneUp()
        {
            if (Core.CollisionDetector.Detect<OneUp>().AnyEdge.Touch)
            {
                SoundManager.OneUpSoundPlay();
            }
        }

        protected virtual void HandleStar()
        {
            if (Core.CollisionDetector.Detect<Star>().AnyEdge.Touch)
            {
                Core.StateController.GetStarPower();
                SoundManager.PowerUpSoundPlay();
            }
        }

        protected virtual void HandleFireflower()
        {
            if (Core.CollisionDetector.Detect<Fireflower>().AnyEdge.Touch)
            {
                Core.DelayCommand(Core.StateController.GetFire, 5);
                SoundManager.PowerUpSoundPlay();
            }
        }

        protected virtual void HandleEnemy()
        {
            var aliveEnemyCollision = Core.CollisionDetector.Detect<IEnemy>(enemy => enemy.Alive);
            var koopaShellRightCollision = Core.CollisionDetector.Detect<Koopa>(koopa => koopa.IsMovingShell && koopa.GoingRight);
            var koopaShellLeftCollision = Core.CollisionDetector.Detect<Koopa>(koopa => koopa.IsMovingShell && koopa.GoingLeft);

            if ((aliveEnemyCollision.AnySide | aliveEnemyCollision.Top).Touch
                || koopaShellLeftCollision.Right.Touch
                || koopaShellRightCollision.Left.Touch
                || (koopaShellLeftCollision + koopaShellRightCollision).Top.Touch)
                Core.StateController.TakeDamage();
            if ((koopaShellLeftCollision + koopaShellRightCollision + aliveEnemyCollision).Bottom.Touch)
                Core.StateController.Bounce();
        }

        protected void HandleFlagPole()
        {
            if (Core.CollisionDetector.Detect<FlagPole>().AnySide.Touch)
                Core.StateController.FinishLevel();
        }
        
        protected void HandlePipe()
        {
            if (Core.CollisionDetector.Detect<IPipe>().Bottom.Cover)
                Core.StateController.FoundWarpPipe();
            else  Core.StateController.LeaveWarpPipe();
        }
    }
}