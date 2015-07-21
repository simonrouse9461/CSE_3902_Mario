using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace MarioGame
{
    public class SecretPipeObject : GreenPipeObject, IPipe
    {
        

        public SecretPipeObject()
        {
            StateController.SpriteState.SecretPipe();
            StateController.isWarp();
        }
    }
}
