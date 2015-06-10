using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Star : ObjectKernel<StarSpriteState, BlankMotionState>
    {
        public  Star(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new StarSpriteState();
            MotionState = new BlankMotionState(location);
        }
    }
}
