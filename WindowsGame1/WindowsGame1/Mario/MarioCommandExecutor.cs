using System;
using System.Collections.Generic;

namespace MarioGame
{
    public class MarioCommandExecutor : CommandExecutorKernel<MarioStateController>
    {
        public MarioCommandExecutor(ICoreNew core) : base(core)
        {
            RegisterCommand(typeof (MarioLeftCommand),
                Core.StateController.AssureLeft,
                Core.StateController.GoLeft,
                Core.StateController.StopMove);
            RegisterCommand(typeof (MarioRightCommand),
                Core.StateController.AssureRight,
                Core.StateController.GoRight,
                Core.StateController.StopMove);
            RegisterCommand(typeof (MarioUpCommand), null,
                Core.StateController.Jump,
                Core.StateController.Fall);
            RegisterCommand(typeof (MarioDownCommand), null,
                Core.StateController.Crouch,
                Core.StateController.StandUp);
            RegisterCommand(typeof (MarioDieCommand), Core.StateController.Die);
            RegisterCommand(typeof(MarioFireCommand), 
                Core.StateController.Sprint,
                Core.StateController.Shoot);
        }
    }
}