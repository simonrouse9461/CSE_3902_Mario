using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class GreenPipeObject : ObjectKernelNew<PipeStateController>{

        private enum Version
        {
            Warp,
            Default
        }

        private Version version = Version.Default;

        public GreenPipeObject WarpPipe
        {
            get
            {
                version = Version.Warp;
                return this;
            }
        }
    }
}
