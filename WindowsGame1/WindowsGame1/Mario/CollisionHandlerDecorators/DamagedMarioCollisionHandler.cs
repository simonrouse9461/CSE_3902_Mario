using System;

namespace WindowsGame1
{
    public class DamagedMarioCollisionHandler : MarioCollisionHandler
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }
        public DamagedMarioCollisionHandler(Core<MarioSpriteState, MarioMotionState> core, MarioCollisionHandler original) : base(core)
        {
            var restoreTime = 200;

            DefaultCollisionHandler = original;
            if (Core.SpriteState.HaveFire)
            {
                Core.SpriteState.BecomeSmall();
            }
            Core.SpriteState.BecomeBlink();
            Core.SpriteState.ChangeColorFrequency(2);
            Core.BarrierDetector.RemoveBarrier<Koopa>();
            Core.BarrierDetector.RemoveBarrier<Goomba>();

            // time up actions
            Core.DelayCommand(() => Core.SpriteState.SetDefaultColor(), () => Core.CollisionHandler is DamagedMarioCollisionHandler, restoreTime);
            Core.DelayCommand(() => Core.BarrierDetector.AddBarrier<Koopa>(), () => Core.CollisionHandler is DamagedMarioCollisionHandler, restoreTime);
            Core.DelayCommand(() => Core.BarrierDetector.AddBarrier<Goomba>(), () => Core.CollisionHandler is DamagedMarioCollisionHandler, restoreTime);

            Core.DelayCommand(() => Core.SwitchComponent(DefaultCollisionHandler), () => Core.CollisionHandler is DamagedMarioCollisionHandler, restoreTime);
        }

        protected override void HandleEnemy() { }

        protected override void HandleStar()
        {
            if (Detector.Detect<Star>().AnyEdge.Touch)
            {
                Core.BarrierDetector.AddBarrier<Koopa>();
                Core.BarrierDetector.AddBarrier<Goomba>();
                Core.SwitchComponent(new StarMarioCollisionHandler(Core, DefaultCollisionHandler));
            }
        }
    }
}