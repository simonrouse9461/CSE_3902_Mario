using System;

namespace MarioGame
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
        }

        protected virtual void HandleMushroom()
        {
            if (Core.CollisionDetector.Detect<Mushroom>().AnyEdge.Touch)
            {
                Core.DelayCommand(Core.StateController.Grow, 5);
                SoundManager.PowerUpSoundPlay();
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
            if (Core.CollisionDetector.Detect<IEnemy>(enemy => enemy.Alive && !enemy.isMovingShell).AnySide.Touch)
            {
                Core.StateController.TakeDamage();
            }
            if (Core.CollisionDetector.Detect<IEnemy>().Bottom.Touch)
            {
                Core.StateController.Bounce();
            }
        }

        protected void HandleFlagPole()
        {
            if (Core.CollisionDetector.Detect<FlagPoleObject>().AnyEdge.Touch)
            {
                Core.StateController.FinishLevel();
            }
        }
    }
}