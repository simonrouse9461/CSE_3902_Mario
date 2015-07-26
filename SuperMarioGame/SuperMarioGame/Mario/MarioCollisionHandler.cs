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
                if (Core.StateController.SpriteState.Small) Core.DelayCommand(Core.StateController.Grow, 5);
                else Core.DelayCommand(Core.StateController.GetFire, 5);
                SoundManager.PowerUpSoundPlay();
            }
        }

        protected virtual void HandleEnemy()
        {
            var collision = Core.CollisionDetector.Detect<IEnemy>(enemy => enemy.Alive && !enemy.isMovingShell);
            if (collision.Left.Touch && !Core.Object.GoingRight || collision.Right.Touch && !Core.Object.GoingLeft)
                Core.StateController.TakeDamage();
            if (collision.Bottom.Touch)
                Core.StateController.Bounce();
        }

        protected void HandleFlagPole()
        {
            if (Core.CollisionDetector.Detect<FlagPoleObject>().AnySide.Touch)
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