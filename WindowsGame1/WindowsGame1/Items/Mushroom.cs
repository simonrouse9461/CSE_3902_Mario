using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Mushroom : ObjectKernelNew<MushroomSpriteState, RightMotionState>
    {
        public Mushroom(WorldManager world) : base(world) { }
        protected override void Initialize()
        {
            SpriteState = new MushroomSpriteState();
            MotionState = new RightMotionState();
        }
        protected override void SyncState()
        {

        }
    }
}
