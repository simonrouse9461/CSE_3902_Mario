using System;

namespace WindowsGame1
{
    public class DamagedMarioCollisionHandler : MarioCollisionHandler
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }
        public DamagedMarioCollisionHandler(CoreNew<MarioStateController> core, MarioCollisionHandler original) : base(core)
        {
            const int restoreTime = 200;

            DefaultCollisionHandler = original;
            Core.StateController.TakeDamage(restoreTime);

            Core.DelayCommand(() => Core.SwitchComponent(DefaultCollisionHandler),
                () => Core.CollisionHandler is DamagedMarioCollisionHandler, restoreTime);
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