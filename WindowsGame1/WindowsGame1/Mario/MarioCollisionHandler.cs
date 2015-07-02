using System;
using WindowsGame1.CommandExecutorDecorators;

namespace WindowsGame1
{
    public class MarioCollisionHandler : CollisionHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioCollisionHandler(Core<MarioSpriteState, MarioMotionState> core) : base(core){}

        public override void Handle()
        {
            if (Core.SpriteState.Dead)
                return;

            HandleFireflower();
            HandleMushroom();
            HandleStar();
            HandleEnemy();
        }

        protected virtual void HandleMushroom()
        {
            if (Detector.Detect<Mushroom>().AnyEdge.Touch)
            {
                if (Core.SpriteState.Small)
                {
                    Core.SpriteState.BecomeBig();
                }
            }
        }

        protected virtual void HandleStar()
        {
            if (Detector.Detect<Star>().AnyEdge.Touch)
            {
                Core.SwitchComponent(new StarMarioCollisionHandler(Core, this));
            } 
        }

        protected virtual void HandleFireflower()
        {
            if (Detector.Detect<Fireflower>().AnyEdge.Touch && !Core.SpriteState.HaveFire)
            {
                Core.SpriteState.GetFire();
                Core.SwitchComponent(new FireMarioCommandExecutor(Core, (MarioCommandExecutor)Core.CommandExecutor));
            }
        }

        protected virtual void HandleEnemy()
        {
            if (Detector.Detect<IEnemy>(enemy => enemy.Alive).AnySide.Touch || Detector.Detect<Koopa>(koopa => koopa.isMovingShell).AnySide.Touch)
            {
                if (Core.SpriteState.Small)
                {
                    Core.SpriteState.BecomeDead();
                }
                if (Core.SpriteState.Big || Core.SpriteState.HaveFire)
                {
                    if (Core.SpriteState.HaveFire)
                        Core.SwitchComponent(((FireMarioCommandExecutor)Core.CommandExecutor).DefaultCommandExecutor);
                    Core.SwitchComponent(new DamagedMarioCollisionHandler(Core, this));
                }
            }
        }
    }
}