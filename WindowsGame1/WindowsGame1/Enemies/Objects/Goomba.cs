using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernel<EnemySpriteState, EnemyMotionState>, IEnemy
    {
        public Goomba()
        {
            SpriteState = new GoombaSpriteState();
            MotionState = new EnemyMotionState();
            CollisionHandler = new EnemyCollisionHandler(State);
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
