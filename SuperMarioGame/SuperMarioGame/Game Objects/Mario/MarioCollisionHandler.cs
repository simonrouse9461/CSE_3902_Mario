using System;

namespace SuperMario
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioStateController>
    {
        public MarioCollisionHandler(ICore core) : base(core){}

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
            var aliveEnemyRightCollision = Core.CollisionDetector.Detect<IEnemy>(enemy => enemy.Alive && enemy.GoingRight);
            var aliveEnemyLeftCollision = Core.CollisionDetector.Detect<IEnemy>(enemy => enemy.Alive && enemy.GoingLeft);
            var koopaShellRightCollision = Core.CollisionDetector.Detect<Koopa>(koopa => koopa.IsMovingShell && koopa.GoingRight);
            var koopaShellLeftCollision = Core.CollisionDetector.Detect<Koopa>(koopa => koopa.IsMovingShell && koopa.GoingLeft);

            if (aliveEnemyLeftCollision.Left.Touch && Core.Object.GoingLeft
                || aliveEnemyRightCollision.Right.Touch && Core.Object.GoingRight
                || (aliveEnemyLeftCollision.Right | aliveEnemyRightCollision.Left).Touch
                ||(aliveEnemyRightCollision + aliveEnemyLeftCollision).Top.Touch
                || koopaShellLeftCollision.Right.Touch
                || koopaShellRightCollision.Left.Touch
                || (koopaShellLeftCollision + koopaShellRightCollision).Top.Touch)
                Core.StateController.TakeDamage();
            if ((koopaShellLeftCollision + koopaShellRightCollision + aliveEnemyLeftCollision + aliveEnemyRightCollision).Bottom.Touch)
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