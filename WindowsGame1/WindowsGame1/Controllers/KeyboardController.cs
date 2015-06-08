using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    public class KeyboardController : ControllerKernel<Keys>
    {
        public override void Update()
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