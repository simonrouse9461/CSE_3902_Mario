using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    public class GamepadController : ControllerKernel<Buttons>
    {
        public override void Update()
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