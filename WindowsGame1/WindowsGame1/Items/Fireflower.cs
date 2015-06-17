using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernel<FireflowerSpriteState, BlankMotionState>
    {
        protected override void Initialize()
        {
            SpriteState = new FireflowerSpriteState();
            MotionState = new BlankMotionState();
            
        }
    }
}
