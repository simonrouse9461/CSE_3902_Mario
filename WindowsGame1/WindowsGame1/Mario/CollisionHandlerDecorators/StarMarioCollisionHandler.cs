using System;

namespace WindowsGame1
{
    public class StarMarioCollisionHandler : MarioCollisionHandler
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }
        public StarMarioCollisionHandler(Core<MarioSpriteState, MarioMotionState> core, MarioCollisionHandler original) : base(core)
        {
            DefaultCollisionHandler = original;
            Core.SpriteState.GetStarPower();
            Core.SpriteState.ChangeColorFrequency(8);

            // time up actions
            Core.DelayCommand(() => Core.SpriteState.ChangeColorFrequency(16), () => Core.CollisionHandler is StarMarioCollisionHandler, 200);
            Core.DelayCommand(() => Core.SpriteState.SetDefaultColor(), () => Core.CollisionHandler is StarMarioCollisionHandler, 300);

            Core.DelayCommand(() => Core.SwitchComponent(DefaultCollisionHandler), () => Core.CollisionHandler is StarMarioCollisionHandler, 300);
        }

        protected override void HandleEnemy() { }
    }
}