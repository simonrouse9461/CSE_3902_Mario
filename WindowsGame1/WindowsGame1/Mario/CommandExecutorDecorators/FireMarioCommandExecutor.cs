using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1.CommandExecutorDecorators
{
    public class FireMarioCommandExecutor : MarioCommandExecutor, IDecorator
    {
        public MarioCommandExecutor DefaultCommandExecutor { get; private set; }
        public FireMarioCommandExecutor(ICore core, ICommandExecutor original) : base(core)
        {
            DefaultCommandExecutor = (MarioCommandExecutor)original;
            RegisterCommand(typeof (MarioFireCommand), null, () => Core.StateController.Shoot());
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