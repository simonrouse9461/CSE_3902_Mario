using System;

namespace SuperMario
{
    public class DamagedMarioCollisionHandler : MarioCollisionHandler, IDecorator
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }
        public DamagedMarioCollisionHandler(ICoreNew core) : base(core)
        {
            DefaultCollisionHandler = (MarioCollisionHandler)core.CollisionHandler;
        }

        public void Restore()
        {
            Core.SwitchComponent(DefaultCollisionHandler);
        }

        public void DelayRestore(int timeDelay)
        {
            Core.DelayCommand(Restore, () => Core.CollisionHandler is DamagedMarioCollisionHandler, timeDelay);
        }

        protected override void HandleEnemy() { }

        protected override void HandleStar()
        {
            if (Core.CollisionDetector.Detect<Star>().AnyEdge.Touch)
            {
                Core.BarrierHandler.AddBarrier<Koopa>();
                Core.BarrierHandler.AddBarrier<Goomba>();
                Core.SwitchComponent(new StarMarioCollisionHandler(Core));
            }
        }
    }
}