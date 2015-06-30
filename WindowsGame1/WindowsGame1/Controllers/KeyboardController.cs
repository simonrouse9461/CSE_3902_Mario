using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class KeyboardController : IController<Keys>
    {
        protected Dictionary<Keys, ICommand> KeysRespondToPress { get; private set; }
        protected Dictionary<Keys, ICommand> KeysRespondToClick { get; private set; }
        protected Dictionary<Keys, bool> LastState { get; private set; }
        protected Collection<Keys> RegisteredKeys { get; private set; }

        public KeyboardController()
        {
            KeysRespondToPress = new Dictionary<Keys, ICommand>();
            KeysRespondToClick = new Dictionary<Keys, ICommand>();
            LastState = new Dictionary<Keys, bool>();
            RegisteredKeys = new Collection<Keys>();
        }

        public void RegisterCommand(Keys key, ICommand command, bool respondToClick)
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
        public void Update()
        { 
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (var key in pressedKeys)
            {
                if (KeysRespondToPress.ContainsKey(key))
                    KeysRespondToPress[key].Execute();
                if (KeysRespondToClick.ContainsKey(key) && !LastState[key])
                    KeysRespondToClick[key].Execute();
            }
            foreach (var key in RegisteredKeys)
            {
                LastState[key] = false;
            }
            foreach (var key in pressedKeys)
            {
                LastState[key] = true;
            }
        }
    }
}