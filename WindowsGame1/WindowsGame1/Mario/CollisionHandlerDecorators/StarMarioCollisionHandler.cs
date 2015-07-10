using System;

namespace WindowsGame1
{
    public class StarMarioCollisionHandler : MarioCollisionHandler
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }
        public StarMarioCollisionHandler(CoreNew<MarioStateController> core, MarioCollisionHandler original) : base(core)
        {
            const int slowDownTime = 200;
            const int stopTime = 300;

            DefaultCollisionHandler = original;
            Core.StateController.GetStarPower(slowDownTime, stopTime);

            Core.DelayCommand(() => Core.SwitchComponent(DefaultCollisionHandler), 
                () => Core.CollisionHandler is StarMarioCollisionHandler, stopTime);
        }

        protected override void HandleEnemy() { }
    }
}