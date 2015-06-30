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

        protected CommandExecutorKernel(Core<TSpriteState, TMotionState> core)
        {
            Core = core;
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
                if (status.Value)
                    CommandAction[status.Key]();
            }

            Reset();
        }
    }
}