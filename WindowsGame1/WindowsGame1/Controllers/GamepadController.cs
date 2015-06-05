using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
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