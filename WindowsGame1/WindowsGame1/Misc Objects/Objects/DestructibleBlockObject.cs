using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockObject : IndestructibleBlockObject
    {

        public DestructibleBlockObject() {
            SpriteState = new BlockSpriteState();
            MotionState = new BlockMotionState();
            State.SpriteState.DestructibleBlock();
            CollisionHandler = new BlockCollisionHandler(State);
        }

        protected override void SyncState()
        {
           
        }
    }

}
