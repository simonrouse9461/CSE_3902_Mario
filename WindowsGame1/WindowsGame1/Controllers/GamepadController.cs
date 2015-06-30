using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class GamepadController : IController<Buttons>
    {
        protected Dictionary<Buttons, ICommand> KeysRespondToPress { get; private set; }
        protected Dictionary<Buttons, ICommand> KeysRespondToClick { get; private set; }
        protected Dictionary<Buttons, bool> LastState { get; private set; }
        protected Collection<Buttons> RegisteredKeys { get; private set; }

        public GamepadController()
        {
            KeysRespondToPress = new Dictionary<Buttons, ICommand>();
            KeysRespondToClick = new Dictionary<Buttons, ICommand>();
            LastState = new Dictionary<Buttons, bool>();
            RegisteredKeys = new Collection<Buttons>();
        }

        public void RegisterCommand(Buttons key, ICommand command, bool respondToClick)
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
            Respond(KeysRespondToPress, true);
            Respond(KeysRespondToClick, false);
        }

        private void Respond(Dictionary<Buttons, ICommand> collection, bool ignoreLastState)
        {
            foreach (var button in collection)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(button.Key) && (!LastState[button.Key] || ignoreLastState))
                {
                    collection[button.Key].Execute();
                    LastState[button.Key] = true;
                }
                else
                {
                    LastState[button.Key] = false;
                }
            }
        }
    }
}