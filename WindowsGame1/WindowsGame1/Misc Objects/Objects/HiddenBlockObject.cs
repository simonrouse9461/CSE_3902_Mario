using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : BlockKernel, IBlock
    {

        private enum Version
        {
            Default,
            ExtraLife,
            Star
        }

        private Version version;

        public HiddenBlockObject() {
            StateController.HiddenBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }

        public static HiddenBlockObject ExtraLifeHiddenBlock
        {
            get
            {
                return new HiddenBlockObject
                {
                    version = Version.ExtraLife
                };               
            }
        }

        public static HiddenBlockObject StarHiddenBlock
        {
            get
            {
                return new HiddenBlockObject
                {
                    version = Version.Star
                };
            }
        }
    }
}
