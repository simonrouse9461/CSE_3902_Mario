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

        private Version version;

        public FloorBlockObject() 
        {
            StateController.FloorBlock();
        }

        public static FloorBlockObject Invisible
        {
            get
            {
                return new FloorBlockObject
                {
                    version = Version.Invisible
                };
            }
        }
    }
}
