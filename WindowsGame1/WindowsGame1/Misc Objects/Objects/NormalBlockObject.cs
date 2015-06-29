using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NormalBlockObject : IndestructibleBlockObject
    {
        public NormalBlockObject() {
            SpriteState = new BlockSpriteState();
            MotionState = new BlockMotionState();
            State.SpriteState.NormalBlock();
            CollisionHandler = new BlockCollisionHandler(State);
        }

        protected override void SyncState()
        {

        }
    }
}
