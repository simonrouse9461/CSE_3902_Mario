using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace WindowsGame1
{
    public class SecretPipeObject : GreenPipeObject
    {
        private enum Version
        {
            Warp
        }

        private Version version = Version.Warp;

        public SecretPipeObject()
        {
            StateController.SpriteState.SecretPipe();
        }
    }
}
