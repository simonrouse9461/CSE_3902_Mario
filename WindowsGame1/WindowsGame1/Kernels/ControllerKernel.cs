using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public abstract class ControllerKernel<T> : IController<T>
    {
        protected Dictionary<T, ICommand> KeysRespondToPress { get; set; }
        protected Dictionary<T, ICommand> KeysRespondToClick { get; set; }
        protected Dictionary<T, bool> LastState { get; set; }
        protected Collection<T> RegisteredKeys { get; set; }

        protected ControllerKernel()
        {
            KeysRespondToPress = new Dictionary<T, ICommand>();
            KeysRespondToClick = new Dictionary<T, ICommand>();
            LastState = new Dictionary<T, bool>();
            RegisteredKeys = new Collection<T>();
        }

        public void RegisterCommand(T key, ICommand command, bool respondToClick)
        {
            if (respondToClick)
            {
                KeysRespondToClick.Add(key, command);
            }
            else
            {
                KeysRespondToPress.Add(key, command);
            }
            LastState.Add(key, false);
            RegisteredKeys.Add(key);
        }

        public abstract void Update();
    }
}