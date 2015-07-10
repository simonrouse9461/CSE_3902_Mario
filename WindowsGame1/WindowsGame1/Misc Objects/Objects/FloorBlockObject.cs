using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class FloorBlockObject : BlockKernel
    {

        private enum Version
        {
            Invisible,
            Default
        }

        private Version version = Version.Default;

        public FloorBlockObject() {
            StateController.FloorBlock();
        }

        public FloorBlockObject Invisible
        {
            get
            {
                version = Version.Invisible;
                return this;
            }
        }
    }
}
