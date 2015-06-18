using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockObject : ObjectKernelNew<DestructibleBlockSpriteState, DestructibleBlockMotionState>
    {

        public DestructibleBlockObject(WorldManager world) : base(world) { }

        protected override void Initialize()
        {
            SpriteState = new DestructibleBlockSpriteState();
            MotionState = new DestructibleBlockMotionState();
            CollisionHandler = new DestructibleBlockCollisionHandler(SpriteState, MotionState, this);
        }

        protected override void SyncState()
        {
           
        }
    }

}
