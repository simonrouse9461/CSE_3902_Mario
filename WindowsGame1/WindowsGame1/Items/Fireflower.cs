using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernel<FireflowerSpriteState, BlankMotionState>
    {
        public Fireflower(Vector2 location) : base(location) { }


        protected override void Initialize(Vector2 location)
        {
            SpriteState = new FireflowerSpriteState();
            MotionState = new BlankMotionState(location);
            
        }
        public override void Reset(Vector2 location)
        {
            SpriteState = new FireflowerSpriteState();
            MotionState = new BlankMotionState(location);
        }
    }
}
