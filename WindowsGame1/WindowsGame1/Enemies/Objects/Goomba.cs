using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernel<GoombaSpriteState, GoombaMotionState>, IEnemy
    {
        public Goomba()
        {
            CollisionHandler = new EnemyCollisionHandler(Core);
        }

        public bool Alive
        {
            get { return !SpriteState.Dead; }
        }
    }
}
