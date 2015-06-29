using System;

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
            if (Detector.Detect<Fireflower>().AnyEdge.Touch)
            {
                Core.SpriteState.GetFire();
            }
        }

        protected virtual void HandleEnemy()
        {
            if (Detector.Detect<IEnemy>(enemy => enemy.Solid && enemy.Alive).AnySide.Touch)
            {
                if (Core.SpriteState.Blinking) return;
                if (Core.SpriteState.Small)
                {
                    Core.SpriteState.BecomeDead();
                    return;
                }
                if (Core.SpriteState.Big || Core.SpriteState.HaveFire)
                {
                    var delayTime = 200;

                    // Enemy damage action
                    Core.SpriteState.BecomeSmall();
                    Core.SpriteState.BecomeBlink();
                    Core.SpriteState.ChangeColorFrequency(2);
                    Core.BarrierDetector.RemoveBarrier<Koopa>();
                    Core.BarrierDetector.RemoveBarrier<Goomba>();

                    // Time up action
                    Core.DelayCommand(() => Core.SpriteState.SetDefaultColor(), () => Core.SpriteState.Blinking, delayTime);
                    Core.DelayCommand(() => Core.BarrierDetector.AddBarrier<Koopa>(), delayTime);
                    Core.DelayCommand(() => Core.BarrierDetector.AddBarrier<Goomba>(), delayTime);
                }
            }
        }
    }
}