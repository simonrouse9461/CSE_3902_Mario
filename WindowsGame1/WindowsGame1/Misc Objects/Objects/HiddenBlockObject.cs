using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : BlockKernel, IBlock
    {

        public HiddenBlockObject() {
            StateController.HiddenBlock();
            CollisionHandler = new HiddenBlockCollisionHandler(Core);
        }

        public static HiddenBlockObject ExtraLifeHiddenBlock
        {
            get
            {
                var instance = new HiddenBlockObject();
                instance.Core.StateController.hasOneUp();
                return instance;
            }
        }
    }
}
