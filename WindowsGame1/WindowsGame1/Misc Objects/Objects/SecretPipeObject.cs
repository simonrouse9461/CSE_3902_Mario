using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace SuperMario
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
