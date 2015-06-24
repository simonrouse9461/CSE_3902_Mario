using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockObject : ObjectKernelNew<DestructibleBlockSpriteState, DestructibleBlockMotionState>
    {

        public DestructibleBlockObject(WorldManager world) : base(world) {

            SpriteState = new DestructibleBlockSpriteState();
            MotionState = new DestructibleBlockMotionState();
            CollisionHandler = new DestructibleBlockCollisionHandler(State);
        }

        protected override void SyncState()
        {
           
        }
    }

}
