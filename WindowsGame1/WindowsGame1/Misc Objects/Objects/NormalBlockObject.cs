using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NormalBlockObject : BlockKernel
    {
        public NormalBlockObject() {
            SpriteState.NormalBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }

        protected void SyncState()
        {
            if (SpriteState.isNormal)
            {
                MotionState.Hit();
            }
        }
    }
}
