using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernelNew<EnemySpriteState, EnemyMotionState>
    {
        public Goomba(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new GoombaSpriteState();
            MotionState = new EnemyMotionState(location);
            CollisionHandler = new EnemyCollisionHandler(SpriteState, MotionState, this);
        }

        protected override void SyncState()
        {
            
        }
    }
}
