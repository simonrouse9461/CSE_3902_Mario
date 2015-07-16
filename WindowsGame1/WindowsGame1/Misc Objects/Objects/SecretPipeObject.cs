using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace WindowsGame1
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
