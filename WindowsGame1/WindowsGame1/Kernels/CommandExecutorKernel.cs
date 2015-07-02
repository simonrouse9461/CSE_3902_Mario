using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public abstract class CommandExecutorKernel<TSpriteState, TMotionState> : ICommandExecutor
        where TSpriteState : SpriteStateKernel
        where TMotionState : MotionStateKernel
    {
        private Dictionary<Type, Action> commandAction;

        public Core<TSpriteState, TMotionState> Core { get; set; }
        protected Dictionary<Type, bool> CommandStatus { get; private set; }

        protected Dictionary<Type, Action> CommandAction
        {
            get { return commandAction; }
            set
            {
                commandAction = value;
                CommandStatus = new Dictionary<Type, bool>();
                foreach (var command in CommandAction)
                {
                    CommandStatus.Add(command.Key, false);
                }
            }
        }

        protected CommandExecutorKernel(ICore core)
        {
            if (core is Core<TSpriteState, TMotionState>)
                Core = (Core<TSpriteState, TMotionState>)core;
            else
                Core = new Core<TSpriteState, TMotionState>
                {
                    Object = core.Object,
                    SpriteState = (TSpriteState)(core.GeneralSpriteState),
                    MotionState = (TMotionState)(core.GeneralMotionState),
                    StateController = core.StateController,
                    CollisionHandler = core.CollisionHandler,
                    CommandExecutor = core.CommandExecutor,
                    BarrierDetector = core.BarrierDetector
                };
        }

        public void Reset()
        {
            foreach (var command in CommandAction)
            {
                CommandStatus[command.Key] = false;
            }
        }

        public void ReadCommand(ICommand command)
        {
            CommandStatus[command.GetType()] = true;
        }

        public void Execute()
        {
            foreach (var status in CommandStatus)
            {
                if (status.Value && CommandAction.ContainsKey(status.Key))
                    CommandAction[status.Key]();
            }

            Reset();
        }
    }
}