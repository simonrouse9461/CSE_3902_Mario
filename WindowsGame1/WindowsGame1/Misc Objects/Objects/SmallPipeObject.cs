using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class SmallPipeObject : GreenPipeObject
    {

        private enum Version
        {
            Warp,
            Default
        }

        private Version version = Version.Default;

        public SmallPipeObject()
        {
            StateController.SpriteState.SmallPipe();
        }

        public static SmallPipeObject SmallWarp
        {
            get
            {
                return new SmallPipeObject
                {
                    version = Version.Warp
                };
            }
        }
    }
}
