using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public  class Koopa : ObjectKernel<EnemySpriteState, EnemyMotionState>, IEnemy
    {
        public Koopa() {
            SpriteState = new KoopaSpriteState();
            MotionState = new EnemyMotionState();
            CollisionHandler = new EnemyCollisionHandler(Core);
        }
        public bool Alive
        {
            get { return !SpriteState.Dead; }
        }

        protected override void SyncState()
        {

        }
    }
}
