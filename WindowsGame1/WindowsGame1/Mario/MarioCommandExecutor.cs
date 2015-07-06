using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCommandExecutor : CommandExecutorKernel<MarioStateController>
    {
        public MarioCommandExecutor(ICore core) : base(core)
        {
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof (MarioLeftCommand), () => Core.StateController.GoLeft()},
                {typeof (MarioRightCommand), () => Core.StateController.GoRight()},
                {typeof (MarioUpCommand), () => Core.StateController.Jump()},
                {typeof (MarioDownCommand), () => Core.StateController.Crouch()}
            };
        }
    }
}