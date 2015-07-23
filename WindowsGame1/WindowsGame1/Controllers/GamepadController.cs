using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class GamepadController : IController<Buttons>
    {
        protected Dictionary<Buttons, ICommand> KeyMappings { get; private set; }

        public GamepadController()
        {
            KeyMappings = new Dictionary<Buttons, ICommand>();
        }

        public void RegisterCommand(Buttons key, ICommand command)
        {
            KeyMappings.Add(key, command);
        }
        public void Update()
        {
            foreach (var button in KeyMappings)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(button.Key))
                {
                    button.Value.Execute();
                }
            }
        }
    }
}