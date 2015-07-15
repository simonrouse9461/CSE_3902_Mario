using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1.CommandExecutorDecorators
{
    public class TransformingMarioCommandExecutor : MarioCommandExecutor, IDecorator
    {
        public MarioCommandExecutor DefaultCommandExecutor { get; private set; }
        public TransformingMarioCommandExecutor(ICore core) : base(core)
        {
            DefaultCommandExecutor = (MarioCommandExecutor)core.CommandExecutor;
            ClearCommands();
            RegisterCommand(typeof (MarioDieCommand), () => Core.StateController.Die());
        }
        public void Restore()
        {
            Core.SwitchComponent(DefaultCommandExecutor);
        }

        public void DelayRestore(int timeDelay)
        {
            Core.DelayCommand(Restore, () => Core.CommandExecutor == this, timeDelay);
        }
    }
}