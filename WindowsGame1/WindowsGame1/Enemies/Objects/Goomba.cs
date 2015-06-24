using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernelNew<EnemySpriteState, EnemyMotionState>
    {
        public Goomba(WorldManager world) : base(world)
        {
            SpriteState = new GoombaSpriteState();
            MotionState = new EnemyMotionState();
            CollisionHandler = new EnemyCollisionHandler(State);
        }

        public bool Alive
        {
            get { return SpriteState.Alive; }
        }

        protected override void SyncState()
        {

        }
        
    }
}
