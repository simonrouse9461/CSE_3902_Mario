using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Fireflower : ObjectKernelNew<FireflowerSpriteState, BlankMotionState>
    {
        public Fireflower(WorldManager world) : base(world) { }
        protected override void Initialize() 
        {
            SpriteState = new FireflowerSpriteState();
            MotionState = new BlankMotionState();            
        }
        protected override void SyncState()
        {

        }
    }
}
