using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class NormalBlockObject : ObjectKernelNew<NormalBlockSpriteState, NormalBlockMotionState>
    {
        public NormalBlockObject(Vector2 location, WorldManager world) : base(location, world) { }

        protected override void Initialize(Vector2 location)
        {
            SpriteState = new NormalBlockSpriteState();
            MotionState = new NormalBlockMotionState(location);
            CollisionHandler = new NormalBlockCollisionHandler(SpriteState, MotionState, this);
        }

        public void NormalBlockDestroyed()
        {
            SpriteState.Status = NormalBlockSpriteState.StatusEnum.Destroyed;
        }

        public void NormalBlockUsed()
        {
            SpriteState.Status = NormalBlockSpriteState.StatusEnum.UsedBlock;
        }

        public void NormalBlockReset()
        {
            SpriteState.Status = NormalBlockSpriteState.StatusEnum.Normal;
        }

        protected override void SyncState()
        {

        }
    }
}
