using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernelNew<GoombaSpriteState, GoombaMotionState>
    {
        public Goomba(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new GoombaSpriteState();
            MotionState = new GoombaMotionState(location);
            CollisionHandler = new GoombaCollisionHandler(SpriteState, MotionState, this);
        }

        protected override void SyncState()
        {
            
        }
    }
}
