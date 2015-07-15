using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WindowsGame1
{
    public abstract class CommandExecutorKernel<TStateController> : ICommandExecutor
        where TStateController : IStateController, new()
    {
        public Core<TStateController> Core { get; set; }
        private Collection<Type> RegisteredCommands { get; set; }
        private Collection<StatusSwitch<Type>> CurrentStatus { get; set; }
        private Collection<StatusSwitch<Type>> PreviousStatus { get; set; }
        private Dictionary<Type, Action> ReceptionActions { get; set; }
        private Dictionary<Type, Action> CommandActions { get; set; }
        private Dictionary<Type, Action> InterruptionActions { get; set; }

        protected void RegisterCommand(Type type, Action action, Action receive = null, Action interrupt = null)
        {
            action = action ?? (() => { });
            receive = receive ?? (() => { });
            interrupt = interrupt ?? (() => { });
            RegisteredCommands.Add(type);
            CommandActions.Add(type, action);
            ReceptionActions.Add(type, receive);
            InterruptionActions.Add(type, interrupt);
            CurrentStatus.Add(new StatusSwitch<Type>(type));
            PreviousStatus.Add(new StatusSwitch<Type>(type));
        }

        protected CommandExecutorKernel(ICore core)
        {
            if (core is Core<TStateController>)
                Core = (Core<TStateController>)core;
            else
                Core = new Core<TStateController>(core.Object)
                {
                    StateController = (TStateController)core.GeneralStateController,
                    CollisionHandler = core.CollisionHandler,
                    CommandExecutor = core.CommandExecutor,
                    BarrierHandler = core.BarrierHandler
                };
            RegisteredCommands = new Collection<Type>();
            CurrentStatus = new Collection<StatusSwitch<Type>>();
            PreviousStatus = new Collection<StatusSwitch<Type>>();
            CommandActions = new Dictionary<Type, Action>();
            ReceptionActions = new Dictionary<Type, Action>();
            InterruptionActions = new Dictionary<Type, Action>();
        }

        public void Reset()
        {
            foreach (var status in CurrentStatus)
            {
                status.Toggle(false);
            }
        }

        protected void ClearCommands()
        {
            RegisteredCommands.Clear();
            CommandActions.Clear();
            ReceptionActions.Clear();
            InterruptionActions.Clear();
            CurrentStatus.Clear();
            PreviousStatus.Clear();
        }

        public void ReadCommand(ICommand command)
        {
            ToggleCurrentStatus(command.GetType(), true);
        }

        public void Execute()
        {
            foreach (var command in RegisteredCommands)
            {
                if (GetCurrentStatus(command)) CommandActions[command]();
                if (GetCurrentStatus(command) && !GetPreviousStatus(command)) ReceptionActions[command]();
                if (!GetCurrentStatus(command) && GetPreviousStatus(command)) InterruptionActions[command]();

                TogglePreviousStatus(command, GetCurrentStatus(command));
            }

            Reset();
        }

        private bool GetCurrentStatus(Type command)
        {
            return CurrentStatus.First(c => c.Content == command).Status;
        }

        private bool GetPreviousStatus(Type command)
        {
            return PreviousStatus.First(c => c.Content == command).Status;
        }

        private void ToggleCurrentStatus(Type command, bool status)
        {
            if (RegisteredCommands.Contains(command))
                CurrentStatus.First(c => c.Content == command).Toggle(status);
        }

        private void TogglePreviousStatus(Type command, bool status)
        {
            if (RegisteredCommands.Contains(command))
                PreviousStatus.First(c => c.Content == command).Toggle(status);
        }
    }
}