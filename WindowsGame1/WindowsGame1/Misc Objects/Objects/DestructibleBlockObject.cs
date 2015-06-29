using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockObject : ObjectKernel<DestructibleBlockSpriteState, DestructibleBlockMotionState>
    {

        public DestructibleBlockObject() {

            SpriteState = new DestructibleBlockSpriteState();
            MotionState = new DestructibleBlockMotionState();
            CollisionHandler = new DestructibleBlockCollisionHandler(Core);
        }

        protected override void SyncState()
        {
           
        }
    }

}
