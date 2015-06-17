using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class HiddenBlockObject : ObjectKernelNew<HiddenBlockSpriteState, HiddenBlockMotionState>
    {

        public HiddenBlockObject(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new HiddenBlockSpriteState();
            MotionState = new HiddenBlockMotionState(location);
            CollisionHandler = new HiddenBlockCollisionHandler(SpriteState, MotionState, this);
        }

        public void HiddenBlocktoUsed()
        {
            SpriteState.Status = HiddenBlockSpriteState.StatusEnum.UsedBlock;
        }

        public void HiddenBlockReset()
        {
            SpriteState.Status = HiddenBlockSpriteState.StatusEnum.Hidden;
        }

        protected override void SyncState()
        {

        }
    }

}
