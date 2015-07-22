using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class FloorBlockObject : BlockKernel
    {

        private enum Version
        {
            Invisible,
            Default
        }

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
                };
            }
        }
    }
}
