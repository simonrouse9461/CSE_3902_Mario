using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1.CommandExecutorDecorators
{
    public class TransformingMarioCommandExecutor : MarioCommandExecutor
    {
        public MarioCommandExecutor DefaultCommandExecutor { get; private set; }
        public TransformingMarioCommandExecutor(ICore core, MarioCommandExecutor original) : base(core)
        {
            DefaultCommandExecutor = original;
            ClearCommands();
            RegisterCommand(typeof (MarioDeadCommand), () => Core.StateController.Die());
        }
    }
}