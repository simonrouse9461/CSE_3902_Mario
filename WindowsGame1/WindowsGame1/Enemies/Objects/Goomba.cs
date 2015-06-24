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

        protected override void SyncState()
        {

        }
        
        public bool Alive
        {
            get { return !SpriteState.Dead; }
        }
    }
}
