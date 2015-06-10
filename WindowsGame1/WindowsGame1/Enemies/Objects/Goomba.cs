using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Goomba : ObjectKernel<GoombaSpriteState, GoombaMotionState>
    {
        public  Goomba(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new GoombaSpriteState();
            MotionState = new GoombaMotionState(location);
        }
    }
}
