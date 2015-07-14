using System;
using WindowsGame1.CommandExecutorDecorators;

namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernelNew<MarioStateController>
    {
        public MarioCollisionHandler(ICore core) : base(core){}

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
                if (Core.StateController.SpriteState.Small)
                {
                    Core.StateController.Grow();
                }
            }
        }

        protected virtual void HandleStar()
        {
            if (Core.CollisionDetector.Detect<Star>().AnyEdge.Touch)
            {
                Core.SwitchComponent(new StarMarioCollisionHandler(Core, this));
            } 
        }

        protected virtual void HandleFireflower()
        {
            if (Core.CollisionDetector.Detect<Fireflower>().AnyEdge.Touch && !Core.StateController.SpriteState.HaveFire)
            {
                Core.StateController.GetFire();
            }
        }

        protected virtual void HandleEnemy()
        {
            var collision = Core.CollisionDetector.Detect<IEnemy>(enemy => enemy.Alive);
            if (collision.AnySide.Touch)
            {
                if (Core.StateController.SpriteState.Small)
                {
                    Core.StateController.Die();
                }
                if (Core.StateController.SpriteState.Big || Core.StateController.SpriteState.HaveFire)
                {
                    if (Core.StateController.SpriteState.HaveFire)
                        Core.SwitchComponent(((FireMarioCommandExecutor)Core.CommandExecutor).DefaultCommandExecutor);
                    Core.SwitchComponent(new DamagedMarioCollisionHandler(Core, this));
                }
            }
            collision = Core.CollisionDetector.Detect<IEnemy>();
            if (collision.Bottom.Touch)
            {
                Core.StateController.Bounce();
            }
        }
    }
}