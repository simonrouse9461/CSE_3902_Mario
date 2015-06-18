using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace WindowsGame1
{
    public  class Star : ObjectKernelNew<StarSpriteState, BlankMotionState>
    {
        public Star(WorldManager world) : base(world) { }
        protected override void Initialize()
        {
            SpriteState = new StarSpriteState();
            MotionState = new BlankMotionState();
        }
        protected override void SyncState()
        {

        }
    }
}
