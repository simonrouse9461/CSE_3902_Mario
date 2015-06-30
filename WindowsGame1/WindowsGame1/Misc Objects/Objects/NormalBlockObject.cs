using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NormalBlockObject : IndestructibleBlockObject
    {
        public NormalBlockObject() {
            SpriteState = new BlockSpriteState();
            MotionState = new BlockMotionState();
            SpriteState.NormalBlock();
            CollisionHandler = new BlockCollisionHandler(Core);
        }

        protected override void SyncState()
        {

        }
    }
}
