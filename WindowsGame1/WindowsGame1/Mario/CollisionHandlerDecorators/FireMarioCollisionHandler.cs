using System;
using WindowsGame1.CommandExecutorDecorators;

namespace WindowsGame1
{
    public class FireMarioCollisionHandler : MarioCollisionHandler
    {
        public MarioCollisionHandler DefaultCollisionHandler { get; private set; }
        public FireMarioCollisionHandler(Core<MarioSpriteState, MarioMotionState> core, MarioCollisionHandler original) : base(core)
        {
            DefaultCollisionHandler = original;

            Core.SpriteState.GetFire();
            Core.SwitchComponent(new FireMarioCommandExecutor(Core, (MarioCommandExecutor)Core.CommandExecutor));
        }

        protected override void HandleMushroom() { }
        protected override void HandleFireflower() { }
        protected override void HandleEnemy()
        {
            if (Detector.Detect<IEnemy>(enemy => enemy.Alive).AnySide.Touch)
            {
                Core.SpriteState.BecomeSmall();
                Core.SwitchComponent(((FireMarioCommandExecutor)Core.CommandExecutor).DefaultCommandExecutor);
                Core.SwitchComponent(new DamagedMarioCollisionHandler(Core, this));
            }
        }
    }
}