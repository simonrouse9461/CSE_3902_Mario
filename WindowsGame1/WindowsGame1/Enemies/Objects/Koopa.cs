using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public  class Koopa : ObjectKernelNew<EnemySpriteState, EnemyMotionState>
    {
        public Koopa(WorldManager world) : base(world) {
            SpriteState = new KoopaSpriteState();
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
