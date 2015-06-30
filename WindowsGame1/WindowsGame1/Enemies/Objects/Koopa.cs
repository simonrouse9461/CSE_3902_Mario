using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public  class Koopa : ObjectKernel<KoopaSpriteState, EnemyMotionState>, IEnemy
    {
        public Koopa() {
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
