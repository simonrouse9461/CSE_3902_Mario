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
            CommandAction.Add(typeof(MarioFireCommand), () => {});
        }
    }
}