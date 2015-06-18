using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public  class Koopa : ObjectKernel<EnemySpriteState, EnemyMotionState>
    {
        public Koopa(WorldManager world) : base(world) { }

        protected override void Initialize()
        {
            SpriteState = new KoopaSpriteState();
            MotionState = new EnemyMotionState();
            CollisionHandler = new EnemyCollisionHandler(SpriteState, MotionState, this);
        }

        protected override void SyncState()
        {

        }
    }
}
