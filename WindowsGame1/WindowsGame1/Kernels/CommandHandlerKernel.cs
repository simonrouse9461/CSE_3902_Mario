﻿using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public abstract class CommandHandlerKernel<TSpriteState, TMotionState> : ICommandHandler
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        private Dictionary<Type, Action> commandAction;

        public State<TSpriteState, TMotionState> State { get; set; }
        protected Dictionary<Type, bool> CommandStatus { get; set; }

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

        protected CommandHandlerKernel(State<TSpriteState, TMotionState> state)
        {
            State = state;
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