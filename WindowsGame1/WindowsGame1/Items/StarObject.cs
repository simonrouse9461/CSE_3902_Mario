using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class StarObject : ObjectKernelNew<StarSpriteState, BlankMotionState>
    {
        public  StarObject(Vector2 location) : base(location) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new StarSpriteState();
            MotionState = new BlankMotionState(location);
        }

        protected void Reset()
        {

        }
    }
}
