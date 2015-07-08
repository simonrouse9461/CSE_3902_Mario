using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class KeyboardController : IController<Keys>
    {
        protected Dictionary<Keys, ICommand> KeyMappings { get; private set; }

        public KeyboardController()
        {
            KeyMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            KeyMappings.Add(key, command);
        }
        public void Update()
        { 
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (var key in pressedKeys)
            {
                if (KeyMappings.ContainsKey(key))
                    KeyMappings[key].Execute();
            }
        }
    }
}