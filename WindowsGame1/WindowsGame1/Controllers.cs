using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    public class KeyboardController : IController<Keys>
    {
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                    controllerMappings[key].Execute();
            }
        }
    }

    public class GamepadController : IController<Buttons>
    {
        private Dictionary<Buttons, ICommand> controllerMappings;
        private List<Buttons> registeredButtons;

        public GamepadController()
        {
            controllerMappings = new Dictionary<Buttons, ICommand>();
            registeredButtons = new List<Buttons>();
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            controllerMappings.Add(button, command);
            registeredButtons.Add(button);
        }

        public void Update()
        {
            foreach (Buttons button in registeredButtons)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(button))
                {
                    controllerMappings[button].Execute();
                }
            }
        }
    }
}