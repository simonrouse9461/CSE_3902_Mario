using System;

namespace WindowsGame1
{
    public class DamagedMarioCollisionHandler : MarioCollisionHandler
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }
        public DamagedMarioCollisionHandler(CoreNew<MarioStateController> core, MarioCollisionHandler original) : base(core)
        {
            var restoreTime = 200;

            DefaultCollisionHandler = original;
            Core.StateController.SpriteState.BecomeSmall();
            Core.StateController.SpriteState.BecomeBlink();
            Core.StateController.SpriteState.ChangeColorFrequency(2);
            Core.BarrierHandler.RemoveBarrier<Koopa>();
            Core.BarrierHandler.RemoveBarrier<Goomba>();

            // time up actions
            Core.DelayCommand(() => Core.StateController.SpriteState.SetDefaultColor(), () => Core.CollisionHandler is DamagedMarioCollisionHandler, restoreTime);
            Core.DelayCommand(() => Core.BarrierHandler.AddBarrier<Koopa>(), () => Core.CollisionHandler is DamagedMarioCollisionHandler, restoreTime);
            Core.DelayCommand(() => Core.BarrierHandler.AddBarrier<Goomba>(), () => Core.CollisionHandler is DamagedMarioCollisionHandler, restoreTime);

            Core.DelayCommand(() => Core.SwitchComponent(DefaultCollisionHandler), () => Core.CollisionHandler is DamagedMarioCollisionHandler, restoreTime);
        }

        protected override void HandleEnemy() { }

        protected override void HandleStar()
        {
            if (Core.CollisionDetector.Detect<Star>().AnyEdge.Touch)
            {
                Core.BarrierHandler.AddBarrier<Koopa>();
                Core.BarrierHandler.AddBarrier<Goomba>();
                Core.SwitchComponent(new StarMarioCollisionHandler(Core, DefaultCollisionHandler));
            }
        }
    }
}