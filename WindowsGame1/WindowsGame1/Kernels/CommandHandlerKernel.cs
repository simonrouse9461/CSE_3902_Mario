using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public abstract class CommandHandlerKernel<TSpriteState, TMotionState> : ICommandHandler<TSpriteState, TMotionState>
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState 
    {
        protected Dictionary<Type, bool> CommandStatus;
        protected Dictionary<Type, Action<TSpriteState, TMotionState>> CommandAction; 

        protected CommandHandlerKernel()
        {
            Initialize();
            CommandAction = CommandAction ?? new Dictionary<Type, Action<TSpriteState, TMotionState>>();
            CommandStatus = new Dictionary<Type, bool>();
            foreach (var command in CommandAction)
            {
                CommandStatus.Add(command.Key, false);
            }
            Reset();
        }

        protected abstract void Initialize();

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

        public List<Action<TSpriteState, TMotionState>> GetAction()
        {
            var list = new List<Action<TSpriteState, TMotionState>>();
            foreach (var status in CommandStatus)
            {
                if (status.Value)
                    list.Add(CommandAction[status.Key]);
            }

            Reset();

            return list;
        }
    }
}