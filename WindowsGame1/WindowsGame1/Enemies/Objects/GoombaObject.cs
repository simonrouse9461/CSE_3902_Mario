using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class GoombaObject : ObjectKernelNew<GoombaSpriteState, GoombaMotionState>
    {
        public  GoombaObject(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new GoombaSpriteState();
            MotionState = new GoombaMotionState(location);
        }
    }
}
