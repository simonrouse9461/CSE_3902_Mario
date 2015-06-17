using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Star : ObjectKernel<StarSpriteState, BlankMotionState>
    {
        protected override void Initialize()
        {
            SpriteState = new StarSpriteState();
            MotionState = new BlankMotionState();
        }
    }
}
