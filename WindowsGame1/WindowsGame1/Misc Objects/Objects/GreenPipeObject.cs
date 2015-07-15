using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class GreenPipeObject : ObjectKernelNew<PipeStateController>, IPipe
    {

        private enum Version
        {
            Warp,
            Default
        }

        public GreenPipeObject()
        {
            StateController.SpriteState.TallPipe();                
        }
       
        private Version version = Version.Default;

        public static GreenPipeObject WarpPipe
        {
            get
            {
                return new GreenPipeObject
                {
                    version = Version.Warp
                };
            }
        }
    }
}
