using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCommandExecutor : CommandExecutorKernel<MarioStateController>
    {
        public MarioCommandExecutor(ICore core) : base(core)
        {
            RegisterCommand(typeof (MarioLeftCommand), 
                () => Core.StateController.KeepLeft(),
                () => Core.StateController.GoLeft(),
                () => Core.StateController.StopMove());
            RegisterCommand(typeof (MarioRightCommand),
                () => Core.StateController.KeepRight(),
                () => Core.StateController.GoRight(),
                () => Core.StateController.StopMove());
            RegisterCommand(typeof (MarioUpCommand), null,
                () => Core.StateController.Jump(),
                () => Core.StateController.Fall());
            RegisterCommand(typeof (MarioDownCommand), null,
                () => Core.StateController.Crouch(),
                () => Core.StateController.StopCrouch());
        }
    }
}