using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernelNew<EnemySpriteState, EnemyMotionState>
    {
        public Goomba(WorldManager world) : base(world) { }

        protected override void Initialize()
        {
            SpriteState = new GoombaSpriteState();
            MotionState = new EnemyMotionState();
            CollisionHandler = new EnemyCollisionHandler(SpriteState, MotionState, this);
        }

        protected override void SyncState()
        {
            
        }
    }
}
