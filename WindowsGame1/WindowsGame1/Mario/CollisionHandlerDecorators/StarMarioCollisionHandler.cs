using System;

namespace WindowsGame1
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
            Core.DelayCommand(Restore, () => Core.CollisionHandler == this, timeDelay);
        }

        protected override void HandleEnemy() { }
    }
}