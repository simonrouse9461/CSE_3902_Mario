using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : BlockKernel
    {
        public HiddenBlockObject() {
            SpriteState.HiddenBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }
    }

}
