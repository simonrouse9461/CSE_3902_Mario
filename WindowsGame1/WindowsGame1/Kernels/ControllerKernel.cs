using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    public abstract class ControllerKernel<T> : IController<T>
    {
        protected Dictionary<T, ICommand> KeysRespondToPress;
        protected Dictionary<T, ICommand> KeysRespondToClick;
        protected Dictionary<T, bool> LastState;
        protected List<T> RegisteredKeys;

        public ControllerKernel()
        {
            KeysRespondToPress = new Dictionary<T, ICommand>();
            KeysRespondToClick = new Dictionary<T, ICommand>();
            LastState = new Dictionary<T, bool>();
            RegisteredKeys = new List<T>();
        }

        public void RegisterCommand(T key, ICommand command, bool respondToClick = false)
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