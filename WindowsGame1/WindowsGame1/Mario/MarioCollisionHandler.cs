using System;
using WindowsGame1.CommandExecutorDecorators;

namespace WindowsGame1
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
        }

        protected virtual void HandleMushroom()
        {
            if (Core.CollisionDetector.Detect<Mushroom>().AnyEdge.Touch)
            {
                Core.DelayCommand(Core.StateController.Grow, 5);
            }
        }

        protected virtual void HandleStar()
        {
            if (Core.CollisionDetector.Detect<Star>().AnyEdge.Touch)
            {
                Core.StateController.GetStarPower(200, 300);
                SoundManager.changeToStarMusic();
            }
        }

        protected virtual void HandleFireflower()
        {
            if (Core.CollisionDetector.Detect<Fireflower>().AnyEdge.Touch)
            {
                Core.StateController.GetFire();
            }
        }

        protected virtual void HandleEnemy()
        {
            if (Core.CollisionDetector.Detect<IEnemy>(enemy => enemy.Alive).AnySide.Touch)
            {
                Core.StateController.TakeDamage(200);
            }
            if (Core.CollisionDetector.Detect<IEnemy>().Bottom.Touch)
            {
                Core.StateController.Bounce();
            }
        }
    }
}