using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class DestructibleBlockObject : ObjectKernelNew<DestructibleBlockSpriteState, DestructibleBlockMotionState>
    {

        public DestructibleBlockObject(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new DestructibleBlockSpriteState();
            MotionState = new DestructibleBlockMotionState(location);
            CollisionHandler = new DestructibleBlockCollisionHandler(SpriteState, MotionState, this);
        }

        protected override void SyncState()
        {

        }
    }

}
