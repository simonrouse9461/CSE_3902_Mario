using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public  class Koopa : ObjectKernel<KoopaSpriteState, KoopaMotionState>, IEnemy
    {
        public Koopa() {
            CollisionHandler = new EnemyCollisionHandler(Core);
        }
        public bool Alive
        {
            get { return !SpriteState.Dead; }
        }

        public bool isMovingShell
        {
            get { return SpriteState.Dead && MotionState.isMoving; }
        }
    }
}
