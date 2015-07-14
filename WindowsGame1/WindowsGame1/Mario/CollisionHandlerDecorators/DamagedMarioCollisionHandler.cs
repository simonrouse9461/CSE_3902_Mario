using System;

namespace WindowsGame1
{
    public class DamagedMarioCollisionHandler : MarioCollisionHandler, IDecorator
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }
        public DamagedMarioCollisionHandler(ICore core, ICollisionHandler original) : base(core)
        {
            DefaultCollisionHandler = (MarioCollisionHandler)original;
        }

        public void Restore()
        {
            Core.SwitchComponent(DefaultCollisionHandler);
        }

        public void DelayRestore(int timeDelay)
        {
            Core.DelayCommand(Restore, () => Core.CollisionHandler == this, timeDelay);
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