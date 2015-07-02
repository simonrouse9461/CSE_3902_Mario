using System;
using System.Collections.Generic;

namespace WindowsGame1.CommandExecutorDecorators
{
    public class FireMarioCommandExecutor : MarioCommandExecutor
    {
        public MarioCommandExecutor DefaultCommandExecutor { get; private set; }
        public FireMarioCommandExecutor(Core<MarioSpriteState, MarioMotionState> core, MarioCommandExecutor original) : base(core)
        {
            DefaultCommandExecutor = original;
            CommandAction.Add(typeof(MarioFireCommand), () =>
            {
                Core.SpriteState.Shoot();
                if (Core.SpriteState.Left)
                    Core.Object.Generate(new FireballObject().LeftFireBall);
                else
                    Core.Object.Generate(new FireballObject().RightFireBall);
            });
        }
    }
}