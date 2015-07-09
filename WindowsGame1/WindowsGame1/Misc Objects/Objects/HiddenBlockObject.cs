using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : BlockKernel
    {

        private enum Version
        {
            Default,
            ExtraLife
        }

        private Version version = Version.Default;


        public HiddenBlockObject() {
            StateController.HiddenBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }

        public HiddenBlockObject ExtraLifeHiddenBlock
        {
            get
            {
                version = Version.ExtraLife;
                return this;
            }
        }
    }

}
