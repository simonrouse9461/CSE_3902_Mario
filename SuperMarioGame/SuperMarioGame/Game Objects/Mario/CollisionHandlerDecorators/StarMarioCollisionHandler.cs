using System;

namespace SuperMario
{
    public class StarMarioCollisionHandler : MarioCollisionHandler, IDecorator
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }

        public StarMarioCollisionHandler(ICore core) : base(core)
        {
            DefaultCollisionHandler = (MarioCollisionHandler)core.CollisionHandler;
        }

        public void Restore()
        {
            Core.SwitchComponent(DefaultCollisionHandler);
        }

        public void DelayRestore(int timeDelay)
        {
            Core.DelayCommand(Restore, () => Core.CollisionHandler is StarMarioCollisionHandler, timeDelay);
        }

        protected override void HandleEnemy() { }
    }
}