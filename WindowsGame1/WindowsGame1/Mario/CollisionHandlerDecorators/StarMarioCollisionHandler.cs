using System;

namespace WindowsGame1
{
    public class StarMarioCollisionHandler : MarioCollisionHandler
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }
        public StarMarioCollisionHandler(CoreNew<MarioStateController> core, MarioCollisionHandler original) : base(core)
        {
            DefaultCollisionHandler = original;
            Core.StateController.SpriteState.GetStarPower();
            Core.StateController.SpriteState.ChangeColorFrequency(8);

            // time up actions
            Core.DelayCommand(() => Core.StateController.SpriteState.ChangeColorFrequency(16), () => Core.CollisionHandler is StarMarioCollisionHandler, 200);
            Core.DelayCommand(() => Core.StateController.SpriteState.SetDefaultColor(), () => Core.CollisionHandler is StarMarioCollisionHandler, 299);
            
            Core.DelayCommand(() => Core.SwitchComponent(DefaultCollisionHandler), () => Core.CollisionHandler is StarMarioCollisionHandler, 300);
        }

        protected override void HandleEnemy() { }
    }
}