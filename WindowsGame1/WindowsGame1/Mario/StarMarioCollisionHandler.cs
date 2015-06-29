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

            Core.DelayCommand(() => Core.SpriteState.ChangeColorFrequency(16), () => Core.SpriteState.HaveStarPower, 200);
            Core.DelayCommand(() => Core.SpriteState.SetDefaultColor(), () => Core.SpriteState.HaveStarPower, 300);
            Core.DelayCommand(() => Core.SwitchComponent(DefaultCollisionHandler), 300);
        }

        protected override void HandleEnemy() { }
    }
}