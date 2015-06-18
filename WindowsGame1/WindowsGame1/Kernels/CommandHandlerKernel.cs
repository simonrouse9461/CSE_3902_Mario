using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public abstract class CommandHandlerKernel<TSpriteState, TMotionState> : ICommandHandler
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        protected TSpriteState SpriteState { get; private set; }
        protected TMotionState MotionState { get; private set; }
        protected Dictionary<Type, bool> CommandStatus { get; private set; }
        protected Dictionary<Type, Action> CommandAction { get; set; }

        protected CommandHandlerKernel(TSpriteState spriteState, TMotionState motionState)
        {
            SpriteState = spriteState;
            MotionState = motionState;
            Initialize();
            CommandAction = CommandAction ?? new Dictionary<Type, Action>();
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

        public void Handle()
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